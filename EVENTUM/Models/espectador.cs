//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EVENTUM.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class espectador
    {
        public int esp_id { get; set; }
        public string esp_identificacion { get; set; }
        public string esp_nombre { get; set; }
        public string esp_email { get; set; }
        public Nullable<System.DateTime> esp_fecha_emision { get; set; }
        public string esp_certificado { get; set; }
        public int id_socio { get; set; }
        public int id_propietario { get; set; }
        public string tii_valor { get; set; }
        public string tie_valor { get; set; }
        public string loc_codigo { get; set; }
        public int ven_id { get; set; }
        public int esp_estado { get; set; }
    
        public virtual localidad localidad { get; set; }
        public virtual tipo_espectador tipo_espectador { get; set; }
        public virtual tipo_identificacion tipo_identificacion { get; set; }
        public virtual ventanilla ventanilla { get; set; }
    }
}
