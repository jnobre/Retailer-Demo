using Retailer.Demo.DynamicProperties.Domain.Entities;
using Retailer.Demo.DynamicProperties.Domain.Entities.Enums;
using Retailer.Demo.DynamicProperties.Domain.Repositories.Implementations;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Retailer.Demo.DynamicProperties.Domain.Repositories.Interfaces
{
    public interface IDynamicPropertyRepository : IBaseRepository<DynamicProperty>
    {
        /// <summary>
        /// Gets the dynamic properties by name
        /// </summary>
        /// <param name="name">The dynamic property name.</param>
        /// <returns> A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task<IEnumerable<DynamicProperty>> GetDynamicPropertyByName(string name);

        /// <summary>
        /// Gets the dynamic property by scope
        /// </summary>
        /// <param name="scope">The dynamic property scope.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task<IEnumerable<DynamicProperty>> GetDynamicPropertyByScope(ScopeName scope);

        /// <summary>
        /// Gets the dynamic property by retailer
        /// </summary>
        /// <param name="idRetailer">The retailer identifie.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task<IEnumerable<DynamicProperty>> GetDynamicPropertyByRetailer(Guid idRetailer);

        /// <summary>
        /// Gets the dynamic property by retailer and scope
        /// </summary>
        /// <param name="idRetailer">The retailer identifie.</param>
        /// <param name="scope">The dynamic property scope.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task<IEnumerable<DynamicProperty>> GetDynamicPropertyByRetailerAndScope(ScopeName scope, Guid idRetailer);

        /// <summary>
        /// Gets the dynamic property by retailer and name
        /// </summary>
        /// <param name="scope">The dynamic property scope.</param>
        /// <param name="idRetailer">The retailer identifier.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task<IEnumerable<DynamicProperty>> GetDynamicPropertyByRetailerAndName(ScopeName scope, Guid idRetailer);
    }

}
