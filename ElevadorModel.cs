namespace ProvaAdmissionalCSharpApisul
{
    public class ElevadorModel
    {
        private char _elevador;
        private int _andar;
        private char _turno;

        public int Andar { get => _andar; set => _andar = value; }
        public char Elevador { get => _elevador; set => _elevador = value; }
        public char Turno { get => _turno; set => _turno = value; }

    }
}
