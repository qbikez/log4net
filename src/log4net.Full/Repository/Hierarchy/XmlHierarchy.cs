using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace src.Repository.Hierarchy
{
    public class XmlHierarchy : Hierarchy, IXmlRepositoryConfigurator
    {

        #region Implementation of IXmlRepositoryConfigurator

        /// <summary>
        /// Initialize the log4net system using the specified config
        /// </summary>
        /// <param name="element">the element containing the root of the config</param>
        void IXmlRepositoryConfigurator.Configure(System.Xml.XmlElement element)
        {
            XmlRepositoryConfigure(element);
        }

        /// <summary>
        /// Initialize the log4net system using the specified config
        /// </summary>
        /// <param name="element">the element containing the root of the config</param>
        /// <remarks>
        /// <para>
        /// This method provides the same functionality as the 
        /// <see cref="M:IBasicRepositoryConfigurator.Configure(IAppender)"/> method implemented
        /// on this object, but it is protected and therefore can be called by subclasses.
        /// </para>
        /// </remarks>
        protected void XmlRepositoryConfigure(System.Xml.XmlElement element)
        {
            ArrayList configurationMessages = new ArrayList();

            using (new LogLog.LogReceivedAdapter(configurationMessages))
            {
                XmlHierarchyConfigurator config = new XmlHierarchyConfigurator(this);
                config.Configure(element);
            }

            Configured = true;

            ConfigurationMessages = configurationMessages;

            // Notify listeners
            OnConfigurationChanged(new ConfigurationChangedEventArgs(configurationMessages));
        }

        #endregion Implementation of IXmlRepositoryConfigurator

    }
}
