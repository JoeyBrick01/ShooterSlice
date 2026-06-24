using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended.Input;
using MonoGame.Extended.Graphics;
using MonoGame.Extended.Screens;
using MonoGame.Extended.Screens.Transitions;

namespace ShooterSlice.Scenes;

public class GameScene : GameScreen
{
    private Game1 game => (Game1)Game;
    private SpriteBatch _spriteBatch;

    public GameScene(Game game) : base(game)
    {

    }

    public override void LoadContent()
    {
        base.LoadContent();
        _spriteBatch = new SpriteBatch(game.GraphicsDevice);
    }

    public override void Update(GameTime gameTime)
    {
        // nav to title
        if (game.keyboardState.WasKeyPressed(Keys.Escape))
        {
            ScreenManager.ReplaceScreen(new TitleScene(game), new FadeTransition(GraphicsDevice, Color.Black, 0.5f));
        }
    }

    public override void Draw(GameTime gameTime)
    {
        game.GraphicsDevice.Clear(Color.MonoGameOrange);

        _spriteBatch.Begin();

        _spriteBatch.End();
    }
}