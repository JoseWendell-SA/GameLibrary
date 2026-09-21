using GameLIB.Scripts;
using GameLIB.Scripts.GameComponents;
using GameLIB.Scripts.GameComponents.Physics.Collision;
using GameLIB.Scripts.GameComponents.Graphics;
using GameLIB.Scripts.Input;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using static System.Formats.Asn1.AsnWriter;
using System.Text.Json;
using System.IO;
using GameLIB.Scripts.Interface;
using GameLIB.Scripts.System;

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

    RigidbodySystem rigidbodySystem = new RigidbodySystem();
    CollisionSystem collisionSystem = new CollisionSystem();
    SpriteSystem spriteSystem = new SpriteSystem();

    bool pause = true;

    private SpriteBatch batch;
    private Texture2D texture;
    SpriteFont spriteFont;

    KeyboardState keyboardPrev;

    int offsetMouseWidth = 0;
    int offsetMouseHeight = 0;

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
        offsetMouseWidth = (int)MathF.Floor(wDiff * 0.5f);
        offsetMouseHeight = (int)MathF.Floor(hDiff * 0.5f);
        MouseInput.ConvertWindowWidth(Window.ClientBounds.Width, offsetMouseWidth, RenderWidth, camera.offsetX);
        MouseInput.ConvertWindowHeight(Window.ClientBounds.Height, offsetMouseHeight, RenderHeight, camera.offsetY);
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
        Time.UpdateGameTime(gameTime);
        mouseCur = Mouse.GetState();
        KeyboardState keyboardCur = Keyboard.GetState();
        GamePadState gpCur = GamePad.GetState(PlayerIndex.One);

        rigidbodySystem.Update();
        collisionSystem.Update();
        spriteSystem.Update();

        
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
            gameManager.Update(gameTime);
            camera.Update();
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