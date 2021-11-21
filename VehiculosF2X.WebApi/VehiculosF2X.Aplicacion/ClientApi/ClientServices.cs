using RestSharp;

namespace VehiculosF2X.Aplicacion.ClientApi
{
    public class ClientServices
    {
        public IRestResponse ExecuteAPI(Method method, string url, string token, string jsonToSend)
        {
            string contentType = "application/json";
            var client = new RestClient(url);
            var request = new RestRequest(method);

            request.AddHeader("content-type", contentType);
            if (token != null)
            {
                request.AddParameter("Authorization", string.Format("Bearer " + token), ParameterType.HttpHeader);
            }

            if (jsonToSend != null)
            {
                request.AddParameter("application/json; charset=utf-8", jsonToSend, ParameterType.RequestBody);
            }

            var response = client.Execute(request);
            return response;
        }
    }
}
