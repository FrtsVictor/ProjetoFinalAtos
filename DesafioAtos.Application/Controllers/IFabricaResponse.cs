namespace DesafioAtos.Application.Controllers
{
    /// <summary>
    /// Cria responses para as controllers aceita string, object e string com object
    /// </summary>
    public interface IFabricaResponse
    {
        /// <summary>
        /// Criar response com message.
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        object Criar(string message);
        
        /// <summary>
        /// Cria response com object.
        /// </summary>
        /// <param name="obj"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        object Criar<T>(T obj);
        
        /// <summary>
        /// Cria response com object e mensagem.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="obj"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        object Criar<T>(string message, T obj);
    }
}