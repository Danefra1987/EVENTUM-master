namespace EVENTUM.Models
{
    using System;

    public class MdlPropietarioBSC
    {
        public int pro_id { get; set; }
        public string pro_tipo_id { get; set; }
        public string pro_num_id { get; set; }
        public string pro_nombre { get; set; }
        public string pro_localidad { get; set; }
        public string pro_email { get; set; }
        public string pro_contrato { get; set; }
        public int pro_pases_libres { get; set; }
        public int pro_pases_emitidos { get; set; }
        public int pro_med_tarifa { get; set; }
        public int pro_med_emitidos { get; set; }
        public DateTime pro_fecha_creacion { get; set; }
        public DateTime pro_fecha_actualizacion { get; set; }
        public int pro_estado { get; set; }
    }
}