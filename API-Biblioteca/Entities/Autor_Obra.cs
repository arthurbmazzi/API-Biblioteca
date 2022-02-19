namespace DevCars.API.Entities
{
    public class Autor_Obra
    {
        public Autor_Obra(int codigoObra)
        {
            CodigoObra = codigoObra;
        }

        public int Id { get; private set; }

        public int CodigoObra { get; private set; }
    }
}