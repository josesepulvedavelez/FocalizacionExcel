namespace PapsiviFocalizacion.Web.Models
{
    public class Localizacion
    {
        public FocDepartamento FocDepartamento { get; set; }
        public FocMunicipio FocMunicipio { get; set; }
        public FocEse FocEse { get; set; }

        public Focalizacion Focalizacion { get; set; }
        public List<Focalizacion> LstFocalizacion { get; set; }
    }
}
