using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EVENTUM.Models
{
    public class MdlEnviaCorreo
    {
        public string Email { get; set; }
        public string Asunto { get; set; }
        public string Socio { get; set; }
        public string Parametro2 { get; set; }
        public bool bandera { get; set; }
        public string PathPlantillaCorreo { get; set; }
    }
}