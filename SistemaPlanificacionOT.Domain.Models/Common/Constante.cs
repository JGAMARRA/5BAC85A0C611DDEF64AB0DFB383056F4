using System.ComponentModel;

namespace SistemaPlanificacionOT.Domain.Models.Common
{
    public class Constante
    {
        private string _descripcion, _value, _keyValue;
        public Constante()
        {

        }

        public Constante(string keyValue)
        {
            if (string.IsNullOrEmpty(keyValue)) return;//throw new InvalidEnumArgumentException(nameof(keyValue));
            if (!keyValue.Contains("_")) return; //throw new InvalidEnumArgumentException($"{nameof(keyValue)} no tiene separador _");
            var splitedValues = keyValue.Split('_');
            _descripcion = splitedValues[0];
            _value = splitedValues[1];
            _keyValue = keyValue;
        }

        public string Descripcion
        {
            get => _descripcion;
            set => _descripcion = value;
        }

        public string Codigo
        {
            get => _value; set => _value = value;
        }

        public override string ToString()
        {
            return _keyValue;
        }
    }
}