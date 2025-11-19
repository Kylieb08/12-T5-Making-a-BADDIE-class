using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12_T5_Making_a_BADDIE_class
{
    
    public class Ghost
    {
        private List<Texture2D> _textures;
        private Vector2 _speed;
        private Rectangle _location;
        private int _textureIndex;
        private SpriteEffects _direction;

        public Ghost(List<Texture2D> textures, Rectangle location)
        {
            _textures = textures;
            _speed = Vector2.Zero;
            _location = location;
            _textureIndex = 0;
            _direction = SpriteEffects.None;
        }

        public void Update(MouseState mouseState)
        {
            if (mouseState.X < _location.X)
                _direction = SpriteEffects.FlipHorizontally;

            else
                _direction = SpriteEffects.None;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_textures[_textureIndex], _location, null, Color.White, 0f,
                Vector2.Zero, _direction, 1);
        }
    }
}
