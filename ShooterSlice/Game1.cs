using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Audio;
using MonoGame.Extended.Input;
using MonoGame.Extended.Screens;
using ShooterSlice.Audio;
using ShooterSlice.Scenes;

namespace ShooterSlice;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;

    private readonly ScreenManager _screenManager;
    public static AudioController Audio { get; private set; }

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

        Audio = new AudioController();

        _screenManager.ShowScreen(new TitleScene(this));

        Mouse.SetCursor(MouseCursor.FromTexture2D(_crosshair, _crosshair.Width / 2, _crosshair.Height / 2));
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);

        // TODO: use this.Content to load your game content here
        _crosshair = Content.Load<Texture2D>("images/BirdsEyeSlice_crosshair");
    }

    protected override void Update(GameTime gameTime)
    {
        // TODO: Add your update logic here
        KeyboardExtended.Update();
        MouseExtended.Update();

        Audio.Update();

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
        Audio.Dispose();

        base.UnloadContent();
    }

    public void PlaySong(Song song, bool isRepeating = true)
    {
        Audio.PlaySong(song, isRepeating);
    }

    public void PlaySoundEffect(SoundEffect soundEffect)
    {
        Audio.PlaySoundEffect(soundEffect);
    }

    public void PlaySoundEffect(SoundEffect soundEffect, float volume, float pitch, float pan, bool isLooped)
    {
        Audio.PlaySoundEffect(soundEffect, volume, pitch, pan, isLooped);
    }

    public void PauseAudio()
    {
        Audio.PauseAudio();
    }

    public void ResumeAudio()
    {
        Audio.ResumeAudio();
    }

    public void ToggleMute()
    {
        Audio.ToggleMute();
    }
}
