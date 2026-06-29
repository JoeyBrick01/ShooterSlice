using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended.Input;
using MonoGame.Extended.Graphics;
using MonoGame.Extended.Screens;
using MonoGame.Extended.Screens.Transitions;
using Microsoft.Xna.Framework.Media;
using ShooterSlice.Characters;

namespace ShooterSlice.Scenes;

public class TestENV: GameScreen
{
    private Game1 game => (Game1)Game;
    private SpriteBatch _spriteBatch;

    Texture2D _tile;
    Song _sceneSong;

    Player _player;

    public TestENV(Game game) : base(game)
    {

    }

    public override void LoadContent()
    {
        base.LoadContent();
        _spriteBatch = new SpriteBatch(game.GraphicsDevice);

        _tile = game.Content.Load<Texture2D>("images/GrayTile");

        _sceneSong = game.Content.Load<Song>("audio/castlevania");
        game.PlaySong(_sceneSong);

        // Player Creation
        Texture2D playerTexture = game.Content.Load<Texture2D>("images/TDPlayer");
        Sprite playerSprite = new Sprite(playerTexture);
        _player = new(playerSprite, Vector2.Zero, new Vector2(4, 4));
    }

    public override void Update(GameTime gameTime)
    {
        KeyboardStateExtended keyboard = KeyboardExtended.GetState();
        MouseStateExtended mouse = MouseExtended.GetState();

        // nav to title
        if (keyboard.WasKeyPressed(Keys.Escape))
        {
            ScreenManager.ReplaceScreen(new TitleScene(game), new FadeTransition(GraphicsDevice, Color.Black, 0.5f));
        }
    }

    public override void Draw(GameTime gameTime)
    {
        game.GraphicsDevice.Clear(Color.MonoGameOrange);

        // Draw tiled background, background is just GrayTIle texture that wraps
        _spriteBatch.Begin(samplerState: SamplerState.PointWrap);
        _spriteBatch.Draw(_tile, game.GraphicsDevice.PresentationParameters.Bounds, new Rectangle(Vector2.Zero.ToPoint(), game.GraphicsDevice.PresentationParameters.Bounds.Size), Color.White);
        _spriteBatch.End();

        // Actual scene drawing
        _spriteBatch.Begin(samplerState: SamplerState.PointClamp);
        _player.Draw(_spriteBatch);

        _spriteBatch.End();
    }
}

