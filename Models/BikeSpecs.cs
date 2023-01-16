namespace CompareBikes.Models
{
    public class BikeSpecs
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public string Type { get; set; }
        public double? Rating { get; set; }
        public string? Displacement_ccm { get; set; }
        public double? Power_hp { get; set; }
        public double? Torque_nm { get; set; }
        public string? Engine_cylinder { get; set; }
        public string? Engine_stroke { get; set; }
        public string? Gearbox { get; set; }
        public double? Bore_mm { get; set; }
        public string? Stroke_mm { get; set; }
        public double? Fuel_capacity_lts { get; set; }
        public string? Fuel_system { get; set; }
        public string? Fuel_control { get; set; }
        public string? Cooling_system { get; set; }
        public string? Transmission_type { get; set; }
        public double? Dry_weight_kg { get; set; }
        public int? Wheelbase_mm { get; set; }
        public int? Seat_height_mm { get; set; }
        public string? Front_brakes { get; set; }
        public string? Rear_brakes { get; set; }
        public string? Front_tire { get; set; }
        public string? Rear_tire { get; set; }
        public string? Front_suspension { get; set; }
        public string? Rear_suspension { get; set; }
        public string? Color_options { get; set; }
    }
}
