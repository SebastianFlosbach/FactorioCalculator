﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factorio.Entities.Interfaces.ProductionViewer
{
    /// <summary>
    /// This interface provides the functions needed for the production view logic.
    /// </summary>
    public interface IPVLogic
    {

        /// <summary>
        /// lines which connects the pictures
        /// </summary>
        List<IPVLine> Lines { get; }
    
        /// <summary>
        /// images which are shown
        /// </summary>
        List<IPVImage> Images { get; }

        /// <summary>
        /// labels wich are shown next to the images
        /// </summary>
        List<IPVLabel> Labels { get; }

        /// <summary>
        /// all items which are displayed in the canvas
        /// </summary>
        List<IPVBaseNode> Nodes { get; }

    }
}