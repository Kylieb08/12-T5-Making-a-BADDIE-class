using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
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

        public Ghost(List<Texture2D> textures, Rectangle location)
        {
            _textures = textures;
            _speed = Vector2.Zero;
            _location = location;
            _textureIndex = 0;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_textures[_textureIndex], _location, Color.White);
        }
    }
}
