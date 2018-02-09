// <auto-generated>
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Microsoft.Azure.Management.DataLake.Analytics.Models
{
    using Newtonsoft.Json;
    using System.Linq;

    /// <summary>
    /// SAS token information.
    /// </summary>
    public partial class SasTokenInformation
    {
        /// <summary>
        /// Initializes a new instance of the SasTokenInformation class.
        /// </summary>
        public SasTokenInformation()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the SasTokenInformation class.
        /// </summary>
        /// <param name="accessToken">The access token for the associated Azure
        /// Storage Container.</param>
        public SasTokenInformation(string accessToken = default(string))
        {
            AccessToken = accessToken;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets the access token for the associated Azure Storage Container.
        /// </summary>
        [JsonProperty(PropertyName = "accessToken")]
        public string AccessToken { get; private set; }

    }
}