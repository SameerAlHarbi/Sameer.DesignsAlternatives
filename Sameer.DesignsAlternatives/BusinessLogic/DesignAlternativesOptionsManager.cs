using Sameer.DesignsAlternatives.DataAccess;
using Sameer.DesignsAlternatives.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace Sameer.DesignsAlternatives.BusinessLogic
{
    public class DesignAlternativesOptionsManager : IDisposable
    {
        private readonly DesignAlternativesContext designAlternativesContext;

        public DesignAlternativesOptionsManager(DesignAlternativesContext designAlternativesContext)
        {
            this.designAlternativesContext = designAlternativesContext;
        }

        public async Task<List<Category>> GetAllCategories()
        {
            try
            {
                var Categories = await designAlternativesContext.Categories.Include(c => c.SubCategories.Select(s => s.designOptions)).ToListAsync();
                return Categories;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<DesignOption>> GetAllDesignOptions()
        {
            try
            {
                var Categories = await designAlternativesContext.Categories.Include(c => c.SubCategories.Select(s => s.designOptions)).ToListAsync();
                return Categories.SelectMany(c => c.SubCategories.SelectMany(s => s.designOptions)).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<int> ResetData()
        {
            try
            {
                var categories = new List<Category>()
                {
                new Category
                {
                    Name="Building Orientation",
                    SubCategories = new List<SubCategory>
                    {
                        new SubCategory
                        {
                            Name = "Related To Wind",
                            Description = "The building site sitting orientation to face the likely and unlikely winds ",
                            designOptions = new List<DesignOption>
                            {
                                new DesignOption
                                {
                                    Name="Likely Wind (North Western)",
                                    Description="Building oriented to likely wind side that receives a small amount of sun radiation",
                                    Accessibility=0.50m,
                                    Relation=0.70m,
                                    Size=0.90m,
                                    Cost=0.50m,
                                    Time=0.70m,
                                    Energy=0.90m,
                                    Maintenance = 0.50m,
                                    Aesthetics = 0.10m
                                },
                                new DesignOption
                                {
                                    Name="Unlikely Wind (South Eastern)",
                                    Description="Building oriented to unlikely wind side that receives a large amount of sun radiation",
                                    Accessibility= -0.30m,
                                    Relation=-0.50m,
                                    Size=-0.70m,
                                    Cost=-0.30m,
                                    Time=-0.50m,
                                    Energy=-0.90m,
                                    Maintenance =-0.30m,
                                    Aesthetics = -0.10m
                                },
                            }
                        },
                        new SubCategory
                        {
                            Name = "Related To View",
                            Description = "The building site sitting orientation to have natural or  not natural views",
                            designOptions = new List<DesignOption>
                            {
                                new DesignOption
                                {
                                    Name="Good View (Garden-Sea-Street)",
                                    Description="Building spaces have a wide good natural view (Garden-Sea-Main Street, etc.)",
                                    Accessibility=0.50m,
                                    Relation=0.70m,
                                    Size=0.90m,
                                    Cost=0.30m,
                                    Time=0.50m,
                                    Energy=-0.50m,
                                    Maintenance = 0.70m,
                                    Aesthetics = 0.90m
                                },
                                new DesignOption
                                {
                                    Name="Bad View (Neighborhood)",
                                    Description="Building spaces have a bad or no natural view (Neighborhood- Small Street, etc.)",
                                    Accessibility=-0.50m,
                                    Relation=-0.50m,
                                    Size=-0.70m,
                                    Cost=-0.10m,
                                    Time=-0.70m,
                                    Energy=0.70m,
                                    Maintenance = -0.50m,
                                    Aesthetics = -0.70m
                                },
                            }
                        },
                    }
                },
                new Category
                {
                    Name="Building Envelope",
                    SubCategories = new List<SubCategory>
                    {
                        new SubCategory
                        {
                            Name = "Building Form",
                            Description = "The degree of how different building masses interlocking to the whole form",
                            designOptions = new List<DesignOption>
                            {
                                new DesignOption
                                {
                                    Name="Simple (Regular)",
                                    Description="Simple surface masses interlocking, straight roofs ",
                                    Accessibility=0.90m,
                                    Relation=0.90m,
                                    Size=0.90m,
                                    Cost=0.90m,
                                    Time=0.70m,
                                    Energy=-0.50m,
                                    Maintenance = 0.70m,
                                    Aesthetics = -0.70m
                                },
                                new DesignOption
                                {
                                    Name="Normal (Moderate)",
                                    Description="Normal masses interlocking, straight roofs ",
                                    Accessibility=0.50m,
                                    Relation=0.50m,
                                    Size=0.70m,
                                    Cost=0.50m,
                                    Time=0.50m,
                                    Energy=-0.30m,
                                    Maintenance = 0.50m,
                                    Aesthetics = 0.50m
                                },
                                new DesignOption
                                {
                                    Name="Complex (Sharp)",
                                    Description="Sharp masses interlocking, inclined roofs",
                                    Accessibility=-0.70m,
                                    Relation=-0.70m,
                                    Size=-0.90m,
                                    Cost=-0.90m,
                                    Time=-0.90m,
                                    Energy=0.70m,
                                    Maintenance = -0.90m,
                                    Aesthetics = 0.90m
                                }
                            }
                        },
                        new SubCategory
                        {
                            Name = "Facade Material",
                            Description = "The exterior wall materials used to enclose the building façade and form",
                            designOptions = new List<DesignOption>
                            {
                                new DesignOption
                                {
                                    Name="Precast Concrete",
                                    Description="12\" (305 mm), Precast concrete, U = 0.55",
                                    Accessibility=0.30m,
                                    Relation=0.30m,
                                    Size=0.50m,
                                    Cost=0.70m,
                                    Time=0.90m,
                                    Energy=-0.50m,
                                    Maintenance = 0.50m,
                                    Aesthetics = 0.70m
                                },
                                new DesignOption
                                {
                                    Name="Block (Concrete)",
                                    Description="-12\" (305 mm), Concrete  block, solid, U = 0.36",
                                    Accessibility=0.10m,
                                    Relation=0.10m,
                                    Size=0.30m,
                                    Cost=0.50m,
                                    Time=-0.50m,
                                    Energy=0.50m,
                                    Maintenance = 0.30m,
                                    Aesthetics = 0.50m
                                },
                                new DesignOption
                                {
                                    Name="Brick (Stone)",
                                    Description="-12\" (305 mm), Brick stone, U = 0.31",
                                    Accessibility=-0.10m,
                                    Relation=0.50m,
                                    Size=-0.10m,
                                    Cost=-0.90m,
                                    Time=-0.70m,
                                    Energy=0.90m,
                                    Maintenance = -0.70m,
                                    Aesthetics = 0.90m
                                }
                            }
                        },
                        new SubCategory
                        {
                            Name = "Glazing Percentage (G/W Ratio)",
                            Description ="The ratio of façade glazing area to the same façade of wall area",
                            designOptions = new List<DesignOption>
                            {
                                new DesignOption
                                {
                                    Name="Small (<20%)",
                                    Description="Small glazing façade area with G/W Ratio = <20%",
                                    Accessibility=0.50m,
                                    Relation=0.50m,
                                    Size=0.70m,
                                    Cost=0.70m,
                                    Time=0.50m,
                                    Energy=0.90m,
                                    Maintenance = 0.30m,
                                    Aesthetics = -0.90m
                                },
                                new DesignOption
                                {
                                    Name="Medium (20-50%)",
                                    Description="Average glazing façade area with G/W Ratio =20-50%",
                                    Accessibility=0.30m,
                                    Relation=-0.30m,
                                    Size=-0.50m,
                                    Cost=-0.50m,
                                    Time=-0.30m,
                                    Energy=-0.70m,
                                    Maintenance = -0.50m,
                                    Aesthetics = 0.70m
                                },
                                new DesignOption
                                {
                                    Name="Large (>50%)",
                                    Description="Complete glazing façade area or,  G/W Ratio = >50% ",
                                    Accessibility=-0.10m,
                                    Relation=-0.50m,
                                    Size=-0.70m,
                                    Cost=-0.90m,
                                    Time=-0.50m,
                                    Energy=-0.90m,
                                    Maintenance = -0.70m,
                                    Aesthetics = 0.90m
                                }
                            }
                        }
                    }
                },
                new Category
                {
                    Name="Plan Shape and Complexity",
                    SubCategories = new List<SubCategory>
                    {
                        new SubCategory
                        {
                            Name = "Plan Efficiency (W/F Ratio)",
                            Description ="The ratio of building exterior walls area to the building Gross Floors Area (GFA)",
                            designOptions = new List<DesignOption>
                            {
                                new DesignOption
                                {
                                    Name="Not-Efficient (<70%)",
                                    Description="Less sitting and space efficiency, Less external walls, More economical design ",
                                    Accessibility=-0.30m,
                                    Relation=-0.90m,
                                    Size=-0.70m,
                                    Cost=0.70m,
                                    Time=0.90m,
                                    Energy=-0.50m,
                                    Maintenance = 0.70m,
                                    Aesthetics = -0.30m
                                },
                                new DesignOption
                                {
                                    Name="Acceptable (70-90%)",
                                    Description="Normal sitting and space efficiency, Normal external walls, Normal economical design",
                                    Accessibility=0.50m,
                                    Relation=0.50m,
                                    Size=0.50m,
                                    Cost=-0.70m,
                                    Time=-0.50m,
                                    Energy=0.70m,
                                    Maintenance = -0.50m,
                                    Aesthetics = 0.10m
                                },
                                new DesignOption
                                {
                                    Name="Efficient (>90%)",
                                    Description="More sitting and space efficiency, More external walls, Less economical design",
                                    Accessibility=0.70m,
                                    Relation=0.90m,
                                    Size=0.90m,
                                    Cost=-0.90m,
                                    Time=-0.70m,
                                    Energy=0.90m,
                                    Maintenance = -0.70m,
                                    Aesthetics = 0.50m
                                }
                            }
                        },
                        new SubCategory
                        {
                            Name = "Shape Complexity",
                            Description ="The proportion degree of building plan dimensions and its setting out ",
                            designOptions = new List<DesignOption>
                            {
                                new DesignOption
                                {
                                    Name="Simple (Regular)",
                                    Description="Symmetrical shape : Square, Rectangular, Circular, Hexagonal, Octagonal, etc.",
                                    Accessibility=0.70m,
                                    Relation=0.90m,
                                    Size=0.90m,
                                    Cost=0.90m,
                                    Time=0.70m,
                                    Energy=-0.90m,
                                    Maintenance = 0.70m,
                                    Aesthetics = -0.30m
                                },
                                new DesignOption
                                {
                                    Name="Normal (Moderate)",
                                    Description="Combined shape: Regular shape interlocking with  irregular, narrow, or curvy shapes",
                                    Accessibility=0.50m,
                                    Relation=0.70m,
                                    Size=0.50m,
                                    Cost=-0.50m,
                                    Time=0.50m,
                                    Energy=0.50m,
                                    Maintenance = 0.50m,
                                    Aesthetics = 0.50m
                                },
                                new DesignOption
                                {
                                    Name="Complex (Irregular)",
                                    Description="Complex shape: Irregular shape interlocking with irregular, narrow, curvy shapes",
                                    Accessibility=-0.70m,
                                    Relation=-0.90m,
                                    Size=-0.90m,
                                    Cost=-0.90m,
                                    Time=-0.70m,
                                    Energy=0.90m,
                                    Maintenance = -0.90m,
                                    Aesthetics = 0.70m
                                }
                            }
                        }
                    }
                },
                new Category
                {
                    Name="Storey and Height",
                    SubCategories = new List<SubCategory>
                    {
                        new SubCategory
                        {
                            Name = "Number of Storey",
                            Description ="The number of storeys that building contains to the same floors area",
                            designOptions = new List<DesignOption>
                            {
                                new DesignOption
                                {
                                    Name="Low-Rise (1-2 Storeys)",
                                    Description="1-2 Storeys: Ground and First floors, or only one floor",
                                    Accessibility=0.90m,
                                    Relation=0.70m,
                                    Size=0.50m,
                                    Cost=0.90m,
                                    Time=0.90m,
                                    Energy=0.70m,
                                    Maintenance = 0.90m,
                                    Aesthetics = -0.70m
                                },
                                new DesignOption
                                {
                                    Name="Medium-Rise (3-4 Storeys)",
                                    Description="3-4 Storeys: Ground, First, Second, and Third floors,  or only three floors",
                                    Accessibility=0.50m,
                                    Relation=0.50m,
                                    Size=-0.30m,
                                    Cost=0.50m,
                                    Time=0.50m,
                                    Energy=-0.50m,
                                    Maintenance = -0.70m,
                                    Aesthetics = 0.70m
                                },
                                new DesignOption
                                {
                                    Name="High-Rise (>4 Storeys))",
                                    Description=">4 Storeys : Ground, First, Second, Third, Fourth, and more floors",
                                    Accessibility=-0.50m,
                                    Relation=-0.30m,
                                    Size=-0.50m,
                                    Cost=-0.90m,
                                    Time=-0.70m,
                                    Energy=-0.70m,
                                    Maintenance = -0.90m,
                                    Aesthetics = 0.90m
                                }
                            }
                        },
                        new SubCategory
                        {
                            Name = "Average Storey Height",
                            Description ="The different range of the storeys heights that give the average building height",
                            designOptions = new List<DesignOption>
                            {
                                new DesignOption
                                {
                                    Name="Low (<3.00m)",
                                    Description="Average storeys heights of the building are less than average range",
                                    Accessibility=-0.50m,
                                    Relation=-0.50m,
                                    Size=-0.50m,
                                    Cost=0.70m,
                                    Time=0.70m,
                                    Energy=0.70m,
                                    Maintenance = 0.50m,
                                    Aesthetics = -0.90m
                                },
                                new DesignOption
                                {
                                    Name="Normal (3.00-4.00m)",
                                    Description="Average storeys heights of the building are within average range",
                                    Accessibility=0.50m,
                                    Relation=0.30m,
                                    Size=0.10m,
                                    Cost=0.50m,
                                    Time=0.50m,
                                    Energy=-0.50m,
                                    Maintenance = -0.50m,
                                    Aesthetics = 0.70m
                                },
                                new DesignOption
                                {
                                    Name="High (>4.00m)",
                                    Description="Average storeys heights of the building are more than average range",
                                    Accessibility=0.70m,
                                    Relation=0.50m,
                                    Size=0.30m,
                                    Cost=-0.90m,
                                    Time=-0.70m,
                                    Energy=-0.70m,
                                    Maintenance = -0.70m,
                                    Aesthetics = 0.90m
                                }
                            }
                        }
                    }
                },
                new Category
                {
                    Name="Windows Glazing",
                    SubCategories = new List<SubCategory>
                    {
                        new SubCategory
                        {
                            Name = "Glazing Shape",
                            Description="The outline configuration shape of different building façade windows ",
                            designOptions = new List<DesignOption>
                            {
                                new DesignOption
                                {
                                    Name="Regular Shape",
                                    Description="Simple Shapes, Single Arranged, Determined Size  ",
                                    Accessibility=0.30m,
                                    Relation=0.30m,
                                    Size=0.50m,
                                    Cost=0.70m,
                                    Time=0.90m,
                                    Energy=-0.70m,
                                    Maintenance = 0.70m,
                                    Aesthetics = -0.50m
                                },
                                new DesignOption
                                {
                                    Name="Semi-Regular Shape",
                                    Description="Overlapping Shapes, Multiple Arranged, Determined Size  ",
                                    Accessibility=-0.30m,
                                    Relation=-0.10m,
                                    Size=-0.50m,
                                    Cost=-0.70m,
                                    Time=-0.50m,
                                    Energy=0.50m,
                                    Maintenance = -0.50m,
                                    Aesthetics = 0.70m
                                },
                                new DesignOption
                                {
                                    Name="Irregular Shape",
                                    Description="Overlapping Shapes, Multiple Not-Arranged, Undetermined Size",
                                    Accessibility=-0.50m,
                                    Relation=-0.30m,
                                    Size=-0.70m,
                                    Cost=-0.90m,
                                    Time=-0.70m,
                                    Energy=0.70m,
                                    Maintenance = -0.90m,
                                    Aesthetics = 0.90m
                                }
                            }
                        },
                        new SubCategory
                        {
                            Name = "Glazing Efficiency",
                            Description="The glazing elements features (Panel number, Reflectivity, Thermal Break, U-value) ",
                            designOptions = new List<DesignOption>
                            {
                                new DesignOption
                                {
                                    Name="Low Efficiency",
                                    Description="Single sheet aluminum glazing, Not reflective (<30%), No thermal break, U = (>0.80)",
                                    Accessibility=-0.10m,
                                    Relation=-0.10m,
                                    Size=-0.30m,
                                    Cost=0.70m,
                                    Time=0.50m,
                                    Energy=-0.90m,
                                    Maintenance = 0.30m,
                                    Aesthetics = -0.50m
                                },
                                new DesignOption
                                {
                                    Name="Medium Efficiency",
                                    Description="Double sheets aluminum glazing, Semi-Reflective (30-70%), Thermal break, U = (0.50-0.80)",
                                    Accessibility=0.10m,
                                    Relation=0.10m,
                                    Size=0.10m,
                                    Cost=-0.50m,
                                    Time=-0.30m,
                                    Energy=0.70m,
                                    Maintenance = -0.30m,
                                    Aesthetics = 0.70m
                                },
                                new DesignOption
                                {
                                    Name="High Efficiency",
                                    Description="Triple sheets low-e coating aluminum glazing,  Reflective (>70%), Thermal break, U = (<0.50)",
                                    Accessibility=0.30m,
                                    Relation=0.30m,
                                    Size=0.30m,
                                    Cost=-0.90m,
                                    Time=-0.50m,
                                    Energy=0.90m,
                                    Maintenance = -0.50m,
                                    Aesthetics = 0.90m
                                }
                            }
                        },
                        new SubCategory
                        {
                            Name = "Sun-Breakers Geometry",
                            Description ="The sun-breakers panels configuration and shading areas",
                            designOptions = new List<DesignOption>
                            {
                                new DesignOption
                                {
                                    Name="Simple Shape (1-Panel)",
                                    Description="One panel: vertical or horizontal panel, one-side shading area",
                                    Accessibility=0.30m,
                                    Relation=0.10m,
                                    Size=0.30m,
                                    Cost=0.90m,
                                    Time=0.70m,
                                    Energy=0.50m,
                                    Maintenance = 0.70m,
                                    Aesthetics = 0.50m
                                },
                                new DesignOption
                                {
                                    Name="Normal Shape (2-Panels)",
                                    Description="Two panels: vertical and horizontal panels, two-sides shading areas",
                                    Accessibility=-0.10m,
                                    Relation=-0.10m,
                                    Size=-0.10m,
                                    Cost=-0.70m,
                                    Time=-0.50m,
                                    Energy=0.70m,
                                    Maintenance = -0.50m,
                                    Aesthetics = 0.70m
                                },
                                new DesignOption
                                {
                                    Name="Complex Shape (3-Panels)",
                                    Description="Three panels: two vertical and one horizontal panels, complete shading areas",
                                    Accessibility=-0.30m,
                                    Relation=-0.30m,
                                    Size=-0.30m,
                                    Cost=-0.90m,
                                    Time=-0.70m,
                                    Energy=0.90m,
                                    Maintenance = -0.70m,
                                    Aesthetics = 0.90m
                                }
                            }
                        }
                    }
                },
                new Category
                {
                    Name="Floor Spans",
                    SubCategories = new List<SubCategory>
                    {
                        new SubCategory
                        {
                            Name = "Span Dimension",
                            Description ="The longest distance of usable area between exterior wall and fixed interior element",
                            designOptions = new List<DesignOption>
                            {
                                new DesignOption
                                {
                                    Name="Short (<4.50m)",
                                    Description="Less span efficiency, Normal economical design, Less aesthetics",
                                    Accessibility=-0.30m,
                                    Relation=-0.30m,
                                    Size=-0.50m,
                                    Cost=0.50m,
                                    Time=0.70m,
                                    Energy=0.70m,
                                    Maintenance = 0.70m,
                                    Aesthetics = -0.50m
                                },
                                new DesignOption
                                {
                                    Name="Medium (4.50-6.50m)",
                                    Description="More span efficiency, More economical design, Normal aesthetics",
                                    Accessibility=0.50m,
                                    Relation=0.70m,
                                    Size=0.70m,
                                    Cost=0.70m,
                                    Time=0.50m,
                                    Energy=0.50m,
                                    Maintenance = 0.50m,
                                    Aesthetics = 0.70m
                                },
                                new DesignOption
                                {
                                    Name="Long (>6.50m)",
                                    Description="Normal span efficiency, Less economical design, More aesthetics",
                                    Accessibility=0.70m,
                                    Relation=0.50m,
                                    Size=-0.30m,
                                    Cost=-0.50m,
                                    Time=-0.50m,
                                    Energy=-0.70m,
                                    Maintenance = -0.50m,
                                    Aesthetics = 0.90m
                                }
                            }
                        }
                    }
                },
                new Category
                {
                    Name="Circulation Space",
                    SubCategories = new List<SubCategory>
                    {
                        new SubCategory
                        {
                            Name = "Circulation Area (C/F Ratio)",
                            Description="The ratio of building circulation space area to the building Gross Floors Area (GFA)",
                            designOptions = new List<DesignOption>
                            {
                                new DesignOption
                                {
                                    Name="Low (<15%)",
                                    Description="Entrance halls, Corridors, Stairways, and Lift wells areas are less than average range",
                                    Accessibility=-0.90m,
                                    Relation=-0.70m,
                                    Size=0.70m,
                                    Cost=0.50m,
                                    Time=0.70m,
                                    Energy=0.70m,
                                    Maintenance = 0.70m,
                                    Aesthetics = -0.50m
                                },
                                new DesignOption
                                {
                                    Name="Normal (15-25%)",
                                    Description="Entrance halls, Corridors, Stairways, and Lift wells areas are within average range",
                                    Accessibility=0.70m,
                                    Relation=0.50m,
                                    Size=0.50m,
                                    Cost=0.30m,
                                    Time=0.50m,
                                    Energy=-0.50m,
                                    Maintenance = -0.50m,
                                    Aesthetics = 0.50m
                                },
                                new DesignOption
                                {
                                    Name="High (>25%)",
                                    Description="Entrance halls, Corridors, Stairways, and Lift wells areas are more than average range",
                                    Accessibility=0.90m,
                                    Relation=0.70m,
                                    Size=-0.70m,
                                    Cost=-0.70m,
                                    Time=-0.70m,
                                    Energy=-0.90m,
                                    Maintenance = -0.70m,
                                    Aesthetics = 0.70m
                                }
                            }
                        }
                    }
                }
            };

                foreach (var subCategory in categories.SelectMany(c => c.SubCategories))
                {
                    foreach (var item in subCategory.designOptions)
                    {
                        item.SubCategory = subCategory;
                    }
                }

                var allOptions = categories.SelectMany(c => c.SubCategories.SelectMany(s => s.designOptions)).ToList();

                var newDesignAlternatives = new List<DesignAlternative>
                { 
                    new DesignAlternative
                    {
                        Name = "A",
                        RelatedToWind=allOptions.Where(d => d.SubCategory.Name == "Related To Wind").FirstOrDefault(d => d.Name == "Unlikely Wind (South Eastern)"),
                        RelatedToView=allOptions.Where(d => d.SubCategory.Name == "Related To View").FirstOrDefault(d => d.Name == "Good View (Garden-Sea-Street)"),

                        BuildingForm=allOptions.Where(d => d.SubCategory.Name == "Building Form").FirstOrDefault(d => d.Name == "Simple (Regular)"),
                        FacadeMaterial=allOptions.Where(d => d.SubCategory.Name == "Facade Material").FirstOrDefault(d => d.Name == "Precast Concrete"),
                        GlazingPercentage=allOptions.Where(d => d.SubCategory.Name == "Glazing Percentage (G/W Ratio)").FirstOrDefault(d => d.Name == "Medium (20-50%)"),

                        PlanEfficiency =allOptions.Where(d => d.SubCategory.Name == "Plan Efficiency (W/F Ratio)")
                            .FirstOrDefault(d => d.Name == "Acceptable (70-90%)"),
                        ShapeComplexity =allOptions.Where(d => d.SubCategory.Name == "Shape Complexity")
                            .FirstOrDefault(d => d.Name == "Simple (Regular)"),

                        NumberOfStorey =allOptions.Where(d => d.SubCategory.Name == "Number of Storey")
                            .FirstOrDefault(d => d.Name == "Medium-Rise (3-4 Storeys)"),
                        AverageStoreyHeight =allOptions.Where(d => d.SubCategory.Name == "Average Storey Height")
                            .FirstOrDefault(d => d.Name == "Normal (3.00-4.00m)"),

                        GlazingShape =allOptions.Where(d => d.SubCategory.Name == "Glazing Shape")
                            .FirstOrDefault(d => d.Name == "Irregular Shape"),
                        GlazingEfficiency =allOptions.Where(d => d.SubCategory.Name == "Glazing Efficiency")
                            .FirstOrDefault(d => d.Name == "Medium Efficiency"),
                        SunBreakersGeometry =allOptions.Where(d => d.SubCategory.Name == "Sun-Breakers Geometry")
                            .FirstOrDefault(d => d.Name == "Simple Shape (1-Panel)"),

                        SpanDimension =allOptions.Where(d => d.SubCategory.Name == "Span Dimension")
                            .FirstOrDefault(d => d.Name == "Medium (4.50-6.50m)"),

                        CirculationArea =allOptions.Where(d => d.SubCategory.Name == "Circulation Area (C/F Ratio)")
                            .FirstOrDefault(d => d.Name == "High (>25%)"),
                    },
                    new DesignAlternative
                    {
                        Name = "B",
                        RelatedToWind=allOptions.Where(d => d.SubCategory.Name == "Related To Wind").FirstOrDefault(d => d.Name == "Likely Wind (North Western)"),
                        RelatedToView=allOptions.Where(d => d.SubCategory.Name == "Related To View").FirstOrDefault(d => d.Name == "Good View (Garden-Sea-Street)"),

                        BuildingForm=allOptions.Where(d => d.SubCategory.Name == "Building Form").FirstOrDefault(d => d.Name == "Normal (Moderate)"),
                        FacadeMaterial=allOptions.Where(d => d.SubCategory.Name == "Facade Material").FirstOrDefault(d => d.Name == "Block (Concrete)"),
                        GlazingPercentage=allOptions.Where(d => d.SubCategory.Name == "Glazing Percentage (G/W Ratio)").FirstOrDefault(d => d.Name == "Medium (20-50%)"),

                         PlanEfficiency =allOptions.Where(d => d.SubCategory.Name == "Plan Efficiency (W/F Ratio)")
                            .FirstOrDefault(d => d.Name == "Efficient (>90%)"),
                         ShapeComplexity =allOptions.Where(d => d.SubCategory.Name == "Shape Complexity")
                            .FirstOrDefault(d => d.Name == "Normal (Moderate)"),

                         NumberOfStorey =allOptions.Where(d => d.SubCategory.Name == "Number of Storey")
                            .FirstOrDefault(d => d.Name == "Medium-Rise (3-4 Storeys)"),
                        AverageStoreyHeight =allOptions.Where(d => d.SubCategory.Name == "Average Storey Height")
                            .FirstOrDefault(d => d.Name == "High (>4.00m)"),

                        GlazingShape =allOptions.Where(d => d.SubCategory.Name == "Glazing Shape")
                            .FirstOrDefault(d => d.Name == "Regular Shape"),
                        GlazingEfficiency =allOptions.Where(d => d.SubCategory.Name == "Glazing Efficiency")
                            .FirstOrDefault(d => d.Name == "Low Efficiency"),
                        SunBreakersGeometry =allOptions.Where(d => d.SubCategory.Name == "Sun-Breakers Geometry")
                            .FirstOrDefault(d => d.Name == "Normal Shape (2-Panels)"),

                        SpanDimension =allOptions.Where(d => d.SubCategory.Name == "Span Dimension")
                            .FirstOrDefault(d => d.Name == "Long (>6.50m)"),

                        CirculationArea =allOptions.Where(d => d.SubCategory.Name == "Circulation Area (C/F Ratio)")
                            .FirstOrDefault(d => d.Name == "High (>25%)")
                    },
                    new DesignAlternative
                    {
                        Name = "C",
                        RelatedToWind=allOptions.Where(d => d.SubCategory.Name == "Related To Wind").FirstOrDefault(d => d.Name == "Likely Wind (North Western)"),
                        RelatedToView=allOptions.Where(d => d.SubCategory.Name == "Related To View").FirstOrDefault(d => d.Name == "Good View (Garden-Sea-Street)"),

                        BuildingForm=allOptions.Where(d => d.SubCategory.Name == "Building Form").FirstOrDefault(d => d.Name == "Normal (Moderate)"),
                        FacadeMaterial=allOptions.Where(d => d.SubCategory.Name == "Facade Material").FirstOrDefault(d => d.Name == "Brick (Stone)"),
                        GlazingPercentage=allOptions.Where(d => d.SubCategory.Name == "Glazing Percentage (G/W Ratio)").FirstOrDefault(d => d.Name == "Small (<20%)"),

                         PlanEfficiency =allOptions.Where(d => d.SubCategory.Name == "Plan Efficiency (W/F Ratio)")
                            .FirstOrDefault(d => d.Name == "Efficient (>90%)"),
                         ShapeComplexity =allOptions.Where(d => d.SubCategory.Name == "Shape Complexity")
                            .FirstOrDefault(d => d.Name == "Normal (Moderate)"),

                         NumberOfStorey =allOptions.Where(d => d.SubCategory.Name == "Number of Storey")
                            .FirstOrDefault(d => d.Name == "Medium-Rise (3-4 Storeys)"),
                        AverageStoreyHeight =allOptions.Where(d => d.SubCategory.Name == "Average Storey Height")
                            .FirstOrDefault(d => d.Name == "High (>4.00m)"),

                        GlazingShape =allOptions.Where(d => d.SubCategory.Name == "Glazing Shape")
                            .FirstOrDefault(d => d.Name == "Semi-Regular Shape"),
                        GlazingEfficiency =allOptions.Where(d => d.SubCategory.Name == "Glazing Efficiency")
                            .FirstOrDefault(d => d.Name == "High Efficiency"),
                        SunBreakersGeometry =allOptions.Where(d => d.SubCategory.Name == "Sun-Breakers Geometry")
                            .FirstOrDefault(d => d.Name == "Normal Shape (2-Panels)"),

                        SpanDimension =allOptions.Where(d => d.SubCategory.Name == "Span Dimension")
                            .FirstOrDefault(d => d.Name == "Long (>6.50m)"),

                        CirculationArea =allOptions.Where(d => d.SubCategory.Name == "Circulation Area (C/F Ratio)")
                            .FirstOrDefault(d => d.Name == "Normal (15-25%)")
                    },
                    new DesignAlternative
                    {
                        Name = "D",
                        RelatedToWind=allOptions.Where(d => d.SubCategory.Name == "Related To Wind").FirstOrDefault(d => d.Name == "Likely Wind (North Western)"),
                        RelatedToView=allOptions.Where(d => d.SubCategory.Name == "Related To View").FirstOrDefault(d => d.Name == "Good View (Garden-Sea-Street)"),

                        BuildingForm=allOptions.Where(d => d.SubCategory.Name == "Building Form").FirstOrDefault(d => d.Name == "Complex (Sharp)"),
                        FacadeMaterial=allOptions.Where(d => d.SubCategory.Name == "Facade Material").FirstOrDefault(d => d.Name == "Block (Concrete)"),
                        GlazingPercentage=allOptions.Where(d => d.SubCategory.Name == "Glazing Percentage (G/W Ratio)").FirstOrDefault(d => d.Name == "Large (>50%)"),

                         PlanEfficiency =allOptions.Where(d => d.SubCategory.Name == "Plan Efficiency (W/F Ratio)")
                            .FirstOrDefault(d => d.Name == "Not-Efficient (<70%)"),
                         ShapeComplexity =allOptions.Where(d => d.SubCategory.Name == "Shape Complexity")
                            .FirstOrDefault(d => d.Name == "Simple (Regular)"),

                         NumberOfStorey =allOptions.Where(d => d.SubCategory.Name == "Number of Storey")
                            .FirstOrDefault(d => d.Name == "High-Rise (>4 Storeys))"),
                        AverageStoreyHeight =allOptions.Where(d => d.SubCategory.Name == "Average Storey Height")
                            .FirstOrDefault(d => d.Name == "Normal (3.00-4.00m)"),

                        GlazingShape =allOptions.Where(d => d.SubCategory.Name == "Glazing Shape")
                            .FirstOrDefault(d => d.Name == "Regular Shape"),
                        GlazingEfficiency =allOptions.Where(d => d.SubCategory.Name == "Glazing Efficiency")
                            .FirstOrDefault(d => d.Name == "High Efficiency"),
                        SunBreakersGeometry =allOptions.Where(d => d.SubCategory.Name == "Sun-Breakers Geometry")
                            .FirstOrDefault(d => d.Name == "Complex Shape (3-Panels)"),

                        SpanDimension =allOptions.Where(d => d.SubCategory.Name == "Span Dimension")
                            .FirstOrDefault(d => d.Name == "Short (<4.50m)"),

                        CirculationArea =allOptions.Where(d => d.SubCategory.Name == "Circulation Area (C/F Ratio)")
                            .FirstOrDefault(d => d.Name == "Normal (15-25%)"),
                    },
                    new DesignAlternative
                    {
                        Name = "E",
                        RelatedToWind=allOptions.Where(d => d.SubCategory.Name == "Related To Wind").FirstOrDefault(d => d.Name == "Likely Wind (North Western)"),
                        RelatedToView=allOptions.Where(d => d.SubCategory.Name == "Related To View").FirstOrDefault(d => d.Name == "Bad View (Neighborhood)"),

                        BuildingForm=allOptions.Where(d => d.SubCategory.Name == "Building Form").FirstOrDefault(d => d.Name == "Simple (Regular)"),
                        FacadeMaterial=allOptions.Where(d => d.SubCategory.Name == "Facade Material").FirstOrDefault(d => d.Name == "Precast Concrete"),
                        GlazingPercentage=allOptions.Where(d => d.SubCategory.Name == "Glazing Percentage (G/W Ratio)").FirstOrDefault(d => d.Name == "Medium (20-50%)"),

                         PlanEfficiency =allOptions.Where(d => d.SubCategory.Name == "Plan Efficiency (W/F Ratio)")
                            .FirstOrDefault(d => d.Name == "Acceptable (70-90%)"),
                         ShapeComplexity =allOptions.Where(d => d.SubCategory.Name == "Shape Complexity")
                            .FirstOrDefault(d => d.Name == "Complex (Irregular)"),

                         NumberOfStorey =allOptions.Where(d => d.SubCategory.Name == "Number of Storey")
                            .FirstOrDefault(d => d.Name == "Low-Rise (1-2 Storeys)"),
                        AverageStoreyHeight =allOptions.Where(d => d.SubCategory.Name == "Average Storey Height")
                            .FirstOrDefault(d => d.Name == "Low (<3.00m)"),

                        GlazingShape =allOptions.Where(d => d.SubCategory.Name == "Glazing Shape")
                            .FirstOrDefault(d => d.Name == "Irregular Shape"),
                        GlazingEfficiency =allOptions.Where(d => d.SubCategory.Name == "Glazing Efficiency")
                            .FirstOrDefault(d => d.Name == "Medium Efficiency"),
                        SunBreakersGeometry =allOptions.Where(d => d.SubCategory.Name == "Sun-Breakers Geometry")
                            .FirstOrDefault(d => d.Name == "Complex Shape (3-Panels)"),

                        SpanDimension =allOptions.Where(d => d.SubCategory.Name == "Span Dimension")
                            .FirstOrDefault(d => d.Name == "Medium (4.50-6.50m)"),

                        CirculationArea =allOptions.Where(d => d.SubCategory.Name == "Circulation Area (C/F Ratio)")
                            .FirstOrDefault(d => d.Name == "Low (<15%)"),
                    }
                };

                var allDesignAlternatives = await designAlternativesContext.DesignAlternatives.ToListAsync();
                var currentCategories = await designAlternativesContext.Categories.Include(c => c.SubCategories.Select(s => s.designOptions)).ToListAsync();

                designAlternativesContext.DesignAlternatives.RemoveRange(allDesignAlternatives);
                designAlternativesContext.Categories.RemoveRange(currentCategories);

                designAlternativesContext.Categories.AddRange(categories);
                designAlternativesContext.DesignAlternatives.AddRange(newDesignAlternatives);

                return designAlternativesContext.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<int> Save()
        {
            try
            {
                return await this.designAlternativesContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Dispose()
        {
            designAlternativesContext.Dispose();
        }
    }
}
