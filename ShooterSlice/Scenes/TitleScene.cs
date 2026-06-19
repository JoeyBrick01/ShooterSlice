using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended.Graphics;
using MonoGame.Extended.Input;
using MonoGame.Extended.Screens;
using MonoGame.Extended.Screens.Transitions;

namespace ShooterSlice.Scenes;

public class TitleScene : GameScreen
{
    private SpriteBatch _spriteBatch;

    // Title text properties.
    private readonly string _titleText = "Shooter Slice";
    private SpriteFont _titleFont;
    private Vector2 _titlePosition;
    private Vector2 _titleOrigin;

    public TitleScene(Game game) : base(game)
    {
    }

    public override void LoadContent()
    {
        base.LoadContent();
        _spriteBatch = new SpriteBatch(Game.GraphicsDevice);

        // Title configuration
        _titleFont = Game.Content.Load<SpriteFont>("fonts/TitleFont");
        _titlePosition = new Vector2(Game.GraphicsDevice.PresentationParameters.BackBufferWidth * .5f, Game.GraphicsDevice.PresentationParameters.BackBufferHeight * .2f);
        _titleOrigin = _titleFont.MeasureString(_titleText) * .5f;
    }

    public override void Update(GameTime gameTime)
    {
        KeyboardExtended.Update();
        KeyboardStateExtended keyboardState = KeyboardExtended.GetState();

        // Exit Game
        if (keyboardState.WasKeyPressed(Keys.Escape))
        {
            Game.Exit();
        }

        // nav to GameScene
        if (keyboardState.WasKeyPressed(Keys.E))
        {
            ScreenManager.ReplaceScreen(new GameScene(Game), new FadeTransition(GraphicsDevice, Color.Black, 0.5f));
        }
    }

    public override void Draw(GameTime gameTime)
    {
        Game.GraphicsDevice.Clear(Color.CornflowerBlue);

        _spriteBatch.Begin();

        // Title text
        _spriteBatch.DrawString(
            _titleFont,
            _titleText,
            _titlePosition,
            Color.White,
            0.0f,
            _titleOrigin,
            1.0f,
            SpriteEffects.None,
            0.0f
        );

        _spriteBatch.End();
    }
}