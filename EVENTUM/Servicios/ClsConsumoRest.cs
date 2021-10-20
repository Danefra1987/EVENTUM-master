namespace EVENTUM.Servicios
{
    using EVENTUM.Models;
    using Newtonsoft.Json;
    using System;
    using System.Net;
    using System.Net.Http;
    using System.Threading.Tasks;
    public class ClsConsumoRest
    { 
        /// <summary>
        /// Constructor
        /// </summary>
        public ClsConsumoRest()
        {
        }

        public string strUrlApi = "https://api.fernandor26.sg-host.com/";

        /// <summary>
        /// Metodo que sirve para consumo de rest
        /// </summary>
        /// <typeparam name="T">Tipo de objeto</typeparam>
        /// <param name="_url">Url a consumir</param>
        /// <param name="_httpMethod">Verbo</param>
        /// <returns>Objeto del tipo T</returns>
        public async Task<T> ConsumirApiRest<T>(Uri _url, HttpMethod _httpMethod)
        {
            try
            {
                string strCadena = string.Empty;
                HttpClient _httpClient = new HttpClient();
                HttpResponseMessage response = new HttpResponseMessage();

                if (_httpMethod == HttpMethod.Get)
                    response = await _httpClient.GetAsync(_url);
                else
                {
                    HttpRequestMessage request = new HttpRequestMessage();
                    request.RequestUri = _url;
                    request.Method = _httpMethod;
                    request.Headers.Add("Accept", "application/json");
                    response = await _httpClient.SendAsync(request);
                }

                if (response.StatusCode == HttpStatusCode.OK)
                    strCadena = await response.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<T>(strCadena);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        /// <summary>
        /// Obtiene socios de BSC
        /// </summary>
        /// <param name="strTipo">Tipo Identificacion</param>
        /// <param name="strIdentificacion">Identificación</param>
        /// <returns>Lista Usuario</returns>
        public async Task<MdlSocioBSC> ObtenerSocioAsync(string strTipo, string strIdentificacion)
        {
            Uri _url = new Uri(strUrlApi + "usuario.php?uTipo=" + strTipo + "&uId=" + strIdentificacion);
            MdlSocioBSC objLista = await ConsumirApiRest<MdlSocioBSC>(_url, HttpMethod.Get);
            return objLista;
        }

        /// <summary>
        /// Obtiene propietarios de BSC
        /// </summary>
        /// <param name="strTipo">Tipo Identificacion</param>
        /// <param name="strIdentificacion">Identificación</param>
        /// <returns>Lista Usuario</returns>
        public async Task<MdlPropietarioBSC> ObtenerPropietarioAsync(string strTipo, string strIdentificacion)
        {
            Uri _url = new Uri(strUrlApi + "usuario.php?uTipo=" + strTipo + "&uId=" + strIdentificacion);
            MdlPropietarioBSC objLista = await ConsumirApiRest<MdlPropietarioBSC>(_url, HttpMethod.Get);
            return objLista;
        }
    }
}