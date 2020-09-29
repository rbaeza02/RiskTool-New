

namespace MVC.Client.Extensions.BootStrapper
{
    /// <summary>
    /// Application boot strapper contract. 
    /// </summary>
    public interface IBootStrapper
    {
        /// <summary>
        /// Initializes application
        /// <remarks>
        /// Registry a controller factory
        /// binders
        /// extensions 
        /// ...
        /// </remarks>
        /// </summary>
        void Boot();
    }
}
