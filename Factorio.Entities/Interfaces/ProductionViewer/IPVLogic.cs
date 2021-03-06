﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Factorio.Entities.Interfaces.ProductionViewer
{
    /// <summary>
    /// This interface provides the functions needed for the production view logic.
    /// </summary>
    public interface IPVLogic
    {
        /// <summary>
        /// Margin for tree structure inside the canvas
        /// </summary>
        Thickness Margin { get; }

        /// <summary>
        /// Top container of the tree structure
        /// </summary>
        IPVFactorioItemContainer RootContainer { get; }

        /// <summary>
        /// Lines which connects the pictures
        /// </summary>
        List<IPVLine> Lines { get; }

        /// <summary>
        /// <see cref="IPVFactorioItemContainer"/> that are shown
        /// </summary>
        List<IPVFactorioItemContainer> FactorioItemContainers { get; }
    }
}
