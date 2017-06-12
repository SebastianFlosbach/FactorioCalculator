﻿using Factorio.Entities.Interfaces.ProductionViewer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactorioWpf.Helper
{
    public class Line : IPVLine
    {

        #region Private Variables



        private AssemblyImageHelper m_start;

        private AssemblyImageHelper m_end;



        #endregion

        #region Interface Properties



        /// <summary>
        /// The distance to the canves top for the first point
        /// </summary>
        public int StartTop { get { return m_start.Top + m_start.ImageHeight; } }

        /// <summary>
        /// The diestance to the canvas left for the first point
        /// </summary>
        public int StartLeft { get { return m_start.Left + m_start.ImageWidth / 2; } }

        /// <summary>
        /// The distance to the canves top for the second point
        /// </summary>
        public int EndTop { get { return m_end.Top; } }

        /// <summary>
        /// The diestance to the canvas left for the second point
        /// </summary>
        public int EndLeft { get { return m_end.Left + m_end.ImageWidth / 2; } }



        #endregion

        #region Constructors



        /// <summary>
        /// default constructor
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        public Line(AssemblyImageHelper start, AssemblyImageHelper end)
        {
            m_start = start;
            m_end = end;
        }



        #endregion

    }
}
