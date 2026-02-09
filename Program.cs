using Joguinho.Scripts;
using Joguinho.Scripts.GameComponents;
using Joguinho.Scripts.GameComponents.Physics.Collision;
using Joguinho.Scripts.Graphics;
using Joguinho.Scripts.Graphics.Interface;
using Joguinho.Scripts.Input;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using static System.Formats.Asn1.AsnWriter;
using System.Text.Json;
using System.IO;

class Program : Game
{
    [STAThread]
    static void Main(string[] args)
    {
        using (Program g = new Program())
        {
            g.Run();
        }
    }

    public static readonly int RenderWidth = 320;
    public static readonly int RenderHeight = 240;
    public static RenderTarget2D RenderTarget;
    public static readonly float AspectRatio = (float)RenderWidth / RenderHeight;

    private MouseState mousePrev = new MouseState();
    private MouseState mouseCur;

    Player player;
    Camera camera;
    World world;
    GameManager gameManager;

    double timerToWait = 0.3f;
    double timerToNextDigit = 0;

    bool pause = true;

    private SpriteBatch batch;
    private Texture2D texture;
    SpriteFont spriteFont;

    KeyboardState keyboardPrev;

    int offSetMouseWidth = 0;
    int offSetMouseHeight = 0;

    public static Vector2 mousePosition = new Vector2();

    private Program()
    {
        GraphicsDeviceManager gdm = new GraphicsDeviceManager(this);

        Content.RootDirectory = "Content";

        // Typically you would load a config here...
        gdm.PreferredBackBufferWidth = 1280;
        gdm.PreferredBackBufferHeight = 720;
        gdm.IsFullScreen = false;
        gdm.SynchronizeWithVerticalRetrace = true;
    }

    protected override void Initialize()
    {
        /* This is a nice place to start up the engine, after
         * loading configuration stuff in the constructor
         */
        player = new Player(new Vector2(0, 0));
        camera = new Camera(RenderWidth, RenderHeight);
        world = new World(camera, player);
        gameManager = new GameManager(world);

        base.Initialize();

        IsMouseVisible = true;
        var height = Window.ClientBounds.Height;
        height -= (height % RenderHeight);
        var width = (int)MathF.Floor(height * AspectRatio);
        var wDiff = Window.ClientBounds.Width - width;
        var hDiff = Window.ClientBounds.Height - height;
        offSetMouseWidth = (int)MathF.Floor(wDiff * 0.5f);
        offSetMouseHeight = (int)MathF.Floor(hDiff * 0.5f);
    }

    protected override void LoadContent()
    {
        RenderTarget = new RenderTarget2D(GraphicsDevice, RenderWidth, RenderHeight);

        // Load textures, sounds, and so on in here...
        Content.RootDirectory = "Content";
        batch = new SpriteBatch(GraphicsDevice);
        spriteFont = Content.Load<SpriteFont>("Arial");

        texture = Content.Load<Texture2D>("Teste");

        InterfaceManager.SetWorldAndSpriteBatch(batch, spriteFont);
        ComponentUtilities.InsertTexture(texture);
        MouseInput.ConvertWindowWidth(Window.ClientBounds.Width, offSetMouseWidth, RenderWidth, camera.offsetX);
        MouseInput.ConvertWindowHeight(Window.ClientBounds.Height, RenderHeight, camera.offsetY);

        base.LoadContent();
    }

    protected override void UnloadContent()
    {
        // Clean up after yourself!
        batch.Dispose();
        texture.Dispose();
        base.UnloadContent();
    }

    protected override void Update(GameTime gameTime)
    {
        // Run game logic in here. Do NOT render anything here!
        mouseCur = Mouse.GetState();
        KeyboardState keyboardCur = Keyboard.GetState();
        GamePadState gpCur = GamePad.GetState(PlayerIndex.One);

        
        MouseInput.UpdateMouse();

        Keys[] pressedKeys = keyboardCur.GetPressedKeys();

        if (keyboardCur.IsKeyDown(Keys.L) && keyboardPrev.IsKeyUp(Keys.L) && pause)
        {
            world.InsertObject();
            pause = false;
            gameManager.ChangeGameLevel(1);
        }

        if (gameManager.gameLevel == 1)
        {
            camera.Update();
            gameManager.Update(gameTime);
        }

        else if (gameManager.gameLevel == 2)
        {
            if (keyboardCur.IsKeyDown(Keys.Escape) && keyboardPrev.IsKeyUp(Keys.Escape))
            {
                gameManager.ChangeGameLevel(3);
            }
        }

        else if (gameManager.gameLevel == 3)
        {
            if (gameTime.TotalGameTime.TotalSeconds > timerToNextDigit)
            {
                for (int n = 0; n < pressedKeys.Length; n++)
                {
                    if ((int)pressedKeys[n] >= 65 && (int)pressedKeys[n] <= 90)
                    {
                        if (gameManager.nameIndex == 3)
                        {
                            gameManager.ChangeGameLevel(4);

                            String text = (gameManager.name[0] + "" + gameManager.name[1] + "" + gameManager.name[2] + ": ");
                            FinalScore finalScore = new FinalScore();
                            finalScore.name = text;
                            finalScore.score = gameManager.score;
                            Console.WriteLine(text);

                            var option = new JsonSerializerOptions
                            {
                                WriteIndented = true
                            };

                            using FileStream openStream = File.OpenRead("Save/Scores.json");

                            List<FinalScore> saveScore = new List<FinalScore>();
                            saveScore = JsonSerializer.Deserialize<List<FinalScore>>(openStream);
                            saveScore.Add(finalScore);
                            for (int k = 0 ; k < saveScore.Count ; k++)
                            {
                                int maior = k;

                                for (int m = k+1; m < saveScore.Count; m++)
                                {
                                    if (saveScore[m].score > saveScore[maior].score)
                                    {
                                        maior = m;
                                        Console.WriteLine(saveScore[maior].score);
                                    }
                                }

                                FinalScore aux = saveScore[k];
                                saveScore[k] = saveScore[maior];
                                saveScore[maior] = aux;
                            }
                            var saveFile = JsonSerializer.Serialize<List<FinalScore>>(saveScore, option);
                            gameManager.SetAllScores(saveScore);
                            openStream.Close();
                            File.WriteAllText("Save/Scores.json", saveFile);
                        }

                        if (gameManager.nameIndex < 3)
                        {
                            gameManager.name[gameManager.nameIndex] = (char)pressedKeys[n];
                            gameManager.nameIndex += 1;
                        }
                        Console.WriteLine(gameManager.name);
                    }
                }

                timerToNextDigit = gameTime.TotalGameTime.TotalSeconds + timerToWait;
            }
        }

        mousePrev = mouseCur;
        keyboardPrev = keyboardCur;

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        // Render stuff in here. Do NOT run game logic in here!
        GraphicsDevice.SetRenderTarget(RenderTarget);

        GraphicsDevice.Clear(Color.Black);
        InterfaceManager.DrawElements(texture);

        GraphicsDevice.SetRenderTarget(null);

        batch.Begin();

        var height = Window.ClientBounds.Height;
        height -= (height % RenderHeight);
        var width = (int)MathF.Floor(height * AspectRatio);
        var wDiff = Window.ClientBounds.Width - width;
        var hDiff = Window.ClientBounds.Height - height;
        batch.Draw(RenderTarget, new Rectangle((int)MathF.Floor(wDiff * 0.5f), (int)MathF.Floor(hDiff * 0.5f), width, height), null, Color.White);
        //batch.DrawString(spriteFont, "Hello", new Vector2(0, 0), Color.White);
        batch.End();

        base.Draw(gameTime);
    }
}