using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using FileHelpers;
using System.ComponentModel.DataAnnotations.Schema;

namespace RiverLink.Models
{
    /// <summary>
    /// Main <c>Vehicle</c> class where all properties are set
    /// </summary>
    [IgnoreFirst(1)]
    [DelimitedRecord("|")]
    public class VehicleData
    {
        [StringLength(20)]
        public string PlateNumber { get; set; }
        /// <value>
        /// Gets and sets the vehicle's make
        /// </value>
        [StringLength(32)]
        public string Make { get; set; }
        /// <value>
        /// Gets and sets the vehicle's model
        /// </value>
        [StringLength(32)]
        public string Model { get; set; }
        /// <value>
        /// Gets and sets the year of the vehicle
        /// </value>
        public int Year { get; set; }
        /// <value>
        /// Gets and sets the State of the vehicle
        /// </value>
        //[Required]
        [StringLength(2)]
        public string VehicleState { get; set; }
        /// <value>
        /// Gets and sets the vehicle's status
        /// </value>
        public string VehicleStatus { get; set; }
        /// <value>
        /// Gets and sets the vehicle's class
        /// </value>

        public string VehicleClass { get; set; }
        /// <value>
        /// Gets and sets the transponders associated with the vehicle
        /// </value>

        public string Transponder { get; set; }

        public string TransponderType { get; set; }
    }
}
