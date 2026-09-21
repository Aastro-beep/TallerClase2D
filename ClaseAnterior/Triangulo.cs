using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TallerClase
{
    internal class Triangulo
    {
        private float _base;
        private float _altura;
        public Triangulo (float _base, float _altura)
        {
            this._base = _base;
            this._altura = _altura;
        }
        public float Area()
        {
            return (_base * _altura) / 2;
        }
    }
}
