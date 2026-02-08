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

    bool pause = true;

    private SpriteBatch batch;
    private Texture2D texture;

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

        texture = Content.Load<Texture2D>("Teste");

        //spriteRenderer = new SpriteRenderer(world, batch);

        InterfaceManager.SetWorldAndSpriteBatch(world, batch);
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

        if (keyboardCur.IsKeyDown(Keys.L) && keyboardPrev.IsKeyUp(Keys.L) && pause)
        {
            world.InsertObject();
            pause = false;
        }

        if (!pause)
        {
            camera.Update();
            gameManager.Update();
        }

        mousePrev = mouseCur;
        keyboardPrev = keyboardCur;

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        // Render stuff in here. Do NOT run game logic in here!
        GraphicsDevice.SetRenderTarget(RenderTarget);

        GraphicsDevice.Clear(Color.CornflowerBlue);
        InterfaceManager.DrawElements(texture);

        GraphicsDevice.SetRenderTarget(null);

        batch.Begin();

        var height = Window.ClientBounds.Height;
        height -= (height % RenderHeight);
        var width = (int)MathF.Floor(height * AspectRatio);
        var wDiff = Window.ClientBounds.Width - width;
        var hDiff = Window.ClientBounds.Height - height;
        batch.Draw(RenderTarget, new Rectangle((int)MathF.Floor(wDiff * 0.5f), (int)MathF.Floor(hDiff * 0.5f), width, height), null, Color.White);
        batch.End();

        base.Draw(gameTime);
    }
}