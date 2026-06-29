using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended.Graphics;
using MonoGame.Extended.Input;

namespace ShooterSlice.Characters;

public class Player
{
    private Sprite _sprite;
    private readonly Vector2 Origin;
    public Vector2 Position;
    public int Speed;
    public int Rotation;
    private Vector2 _scale;

    public Player(Sprite sprite, Vector2 pos, Vector2 scale)
    {
        _sprite = sprite;
        Position = pos;
        _scale = scale;

        Origin = new Vector2(sprite.TextureRegion.X / 2, sprite.TextureRegion.Y / 2);
        _sprite.Origin = Origin;
    }

    public void Update(GameTime gameTime)
    {
        KeyboardStateExtended keyboard = KeyboardExtended.GetState();
        MouseStateExtended mouse = MouseExtended.GetState();
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        // SpriteBatch, Sprite, Position, Rotation, Scale
        SpriteBatchExtensions.Draw(spriteBatch, _sprite, Position, Rotation, _scale);
    }

}
