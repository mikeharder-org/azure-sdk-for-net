﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent
{
    using Models;
    using Resource.Fluent.Core;
    using Resource.Fluent;
    using System.Collections.Generic;

    internal static class NetworkManagerExtensions
    {
        // Internal utility funtion
        internal static ISubnet GetAssociatedSubnet(this INetworkManager manager, SubResource subnetRef)
        {
            if (subnetRef == null)
            {
                return null;
            }

            // TODO: Missing ResourceUtils.ParentResourceIdFromResourceId(subnetRef.Id);
            // Replace 'ParentResourcePathFromResourceId' with 'ParentResourceIdFromResourceId'
            var vnetId = ResourceUtils.ParentResourcePathFromResourceId(subnetRef.Id);
            var subnetName = ResourceUtils.NameFromResourceId(subnetRef.Id);

            if (vnetId == null || subnetName == null)
            {
                return null;
            }

            var network = manager.Networks.GetById(vnetId);
            if (network == null)
            {
                return null;
            }

            ISubnet value = null;
            network.Subnets.TryGetValue(subnetName, out value);
            return value;
        }

        /// Internal utility function
        internal static IList<ISubnet> ListAssociatedSubnets(this INetworkManager manager, IList<SubnetInner> subnetRefs)
        {
            IDictionary<string, INetwork> networks = new Dictionary<string, INetwork>();
            IList<ISubnet> subnets = new List<ISubnet>();
            if (subnetRefs != null)
            {
                foreach (SubnetInner subnetRef in subnetRefs)
                {
                    string networkId = ResourceUtils.ParentResourcePathFromResourceId(subnetRef.Id);
                    INetwork network;
                    if (!networks.TryGetValue(networkId, out network))
                    {
                        network = manager.Networks.GetById(networkId);
                        networks[networkId] = network;
                    }
                    if (network != null)
                    {
                        string subnetName = ResourceUtils.NameFromResourceId(subnetRef.Id);
                        ISubnet subnet;
                        if (network.Subnets.TryGetValue(subnetName, out subnet))
                        {
                            subnets.Add(subnet);
                        }
                    }
                }
            }
            return subnets;
        }
    }
}