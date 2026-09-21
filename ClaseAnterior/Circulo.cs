using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TallerClase
{
    internal class Circulo
    {
        private float _radio;
        public Circulo (float _radio)
        {
            this._radio = _radio;
        }
        public float Area()
        {
            return (_radio * _radio) * 3.14f;
        }
    }
}
