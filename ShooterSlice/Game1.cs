using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended.Input;
using MonoGame.Extended.Screens;
using MonoGame.Extended.Screens.Transitions;
using ShooterSlice.Scenes;
using System.Security.Cryptography.X509Certificates;

namespace ShooterSlice;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    private readonly ScreenManager _screenManager;
    public KeyboardStateExtended keyboardState { get; private set; }

    Texture2D _crosshair;

    public Game1()
    {
        // Graphics settings
        _graphics = new GraphicsDeviceManager(this);
        _graphics.PreferredBackBufferWidth = 1280;
        _graphics.PreferredBackBufferHeight = 720;
        _graphics.ApplyChanges();

        Window.Title = "Shooter Slice";

        Content.RootDirectory = "Content";
        IsMouseVisible = true;

        _screenManager = new ScreenManager();
        Components.Add(_screenManager);
    }

    protected override void Initialize()
    {
        // TODO: Add your initialization logic here

        base.Initialize();

        _screenManager.ShowScreen(new TitleScene(this));

 
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);

        // TODO: use this.Content to load your game content here
        _crosshair = Content.Load<Texture2D>("images/BirdsEyeSlice_crosshair");
        Mouse.SetCursor(MouseCursor.FromTexture2D(_crosshair, _crosshair.Width / 2, _crosshair.Height / 2));
    }

    protected override void Update(GameTime gameTime)
    {
        // TODO: Add your update logic here
        KeyboardExtended.Update();
        keyboardState = KeyboardExtended.GetState();

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        // TODO: Add your drawing code here
        _spriteBatch.Begin();
        _spriteBatch.Draw(_crosshair, new Vector2(100, 100), Color.White);
        _spriteBatch.End();

        base.Draw(gameTime);
    }

    protected override void UnloadContent()
    {
        base.UnloadContent();
    }
}
