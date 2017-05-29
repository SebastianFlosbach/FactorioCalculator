﻿using Factorio;
using Factorio.Entities;
using FactorioWpf.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactorioWpf.ViewModels
{
    public class ProductionViewerViewModell : BaseViewModell
    {
        #region Private Variables

        private IFactorioLogic m_logic;

        private FactorioAssembly m_factorioAssembly;
        private List<ImageHelper> m_images;
        private List<Line> m_lines;

        #endregion

        #region Public Properties

        public List<ImageHelper> Images
        {
            get
            {
                if (m_images == null)
                    m_images = new List<ImageHelper>();

                return m_images;
            }
        }

        public List<Line> Lines
        {
            get
            {
                if (m_lines == null)
                    m_lines = new List<Line>();

                return m_lines;
            }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Create new ProductionView for an <see cref="FactorioItem"/>
        /// </summary>
        public ProductionViewerViewModell(IFactorioLogic logic, FactorioItem item)
        {
            m_logic = logic;

            m_factorioAssembly = new FactorioAssembly(item);

            getAssemblyCanvasStructure(m_factorioAssembly, 0, 0);
        }

        #endregion

        /// <summary>
        /// Used to create the Images and Lines that are drawn on the canvas.
        /// </summary>
        /// <param name="assembly">Assembly as tree root</param>
        /// <param name="layer">Current layer of the tree structure</param>
        /// <param name="position">Position of the Root element</param>
        /// <returns>The actuall position of the created AssemblyCanvasStructure</returns>
        private int getAssemblyCanvasStructure(FactorioAssembly assembly, int layer, int position)
        {
            int currentPosition = position;

            // Search for the first free column in this layer
            foreach (ImageHelper image in Images)
            {
                if (image.Row == layer && image.Column >= currentPosition)
                    currentPosition = image.Column + 1;
            }

            // Create new ImageHelper with image of the current assembly
            Images.Add(new ImageHelper(currentPosition, layer, assembly.AssemblyItem.PicturePath));

            int nextPos = currentPosition;

            foreach (FactorioAssembly subAssembly in assembly.SubAssembly)
            {
                nextPos = getAssemblyCanvasStructure(subAssembly, layer + 1, nextPos);

                // Create line between the current assembly and its subassemblies
                Lines.Add(
                    new Line(
                        currentPosition * (ImageHelper.LeftOffset + ImageHelper.Width) + ImageHelper.Width / 2 + ImageHelper.Offset,
                        layer * (ImageHelper.Height + ImageHelper.TopOffset) + ImageHelper.Height + ImageHelper.Offset,
                        nextPos * (ImageHelper.LeftOffset + ImageHelper.Width) + ImageHelper.Width / 2 + ImageHelper.Offset,
                        (layer + 1) * (ImageHelper.Height + ImageHelper.TopOffset) + ImageHelper.Offset
                    ));

                nextPos++;
            }

            return currentPosition;
        }

    }
}
