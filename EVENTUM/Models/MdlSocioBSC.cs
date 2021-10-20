namespace EVENTUM.Models
{
    using System;

    public class MdlSocioBSC
    {
        public int soc_id { get; set; }
        public string soc_tipo_id { get; set; }
        public string soc_num_id { get; set; }
        public string soc_nombre { get; set; }
        public string soc_localidad { get; set; }
        public string soc_email { get; set; }
        public string soc_contrato { get; set; }
        public int soc_pases_libres { get; set; }
        public int soc_pases_emitidos { get; set; }
        public int soc_med_tarifa { get; set; }
        public int soc_med_emitidos { get; set; }
        public DateTime soc_fecha_creacion { get; set; }
        public DateTime soc_fecha_actualizacion { get; set; }
        public int soc_estado { get; set; }
    }
}