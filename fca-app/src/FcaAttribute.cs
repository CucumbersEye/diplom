using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace fca_app.src
{
    /// <summary>
    ///     Класс атрибутов
    /// </summary>
    class FcaAttribute
    {
        private string name;
        private int id;

        public FcaAttribute() { 
        }

        public void setName(string name) {
            this.name = name;
        }

        public string getName()
        {
            return this.name;
        }

        public void setId(int id)
        {
            this.id = id;
        }

        public int getId()
        {
            return this.id;
        }
    }
}
