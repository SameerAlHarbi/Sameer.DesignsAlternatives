using Sameer.DesignsAlternatives.DataAccess;
using Sameer.DesignsAlternatives.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace Sameer.DesignsAlternatives.BusinessLogic
{
    public class DesignAlternativesManager : IDisposable
    {
        private readonly DesignAlternativesContext designAlternativesContext;

        public DesignAlternativesManager(DesignAlternativesContext designAlternativesContext)
        {
            this.designAlternativesContext = designAlternativesContext;
        }

        public void Dispose()
        {
            designAlternativesContext.Dispose();
        }

        public async Task<List<DesignAlternative>> GetAllDesignAlternatives()
        {
            try
            {
                    var allDesignAlternatives = await designAlternativesContext
                        .DesignAlternatives
                        .Include(d => d.RelatedToWind.SubCategory.Category)
                        .Include(d => d.RelatedToView)
                        .Include(d => d.BuildingForm)
                        .Include(d => d.FacadeMaterial)
                        .Include(d => d.GlazingPercentage)
                        .Include(d => d.PlanEfficiency)
                        .Include(d => d.ShapeComplexity)
                        .Include(d => d.GlazingShape)
                        .Include(d => d.GlazingEfficiency)
                        .Include(d => d.SunBreakersGeometry)
                        .Include(d => d.NumberOfStorey)
                        .Include(d => d.AverageStoreyHeight)
                        .Include(d => d.SpanDimension)
                        .Include(d => d.CirculationArea)
                        .OrderBy(d => d.Name).ToListAsync();

                if(allDesignAlternatives.Count <1)
                {
                    return allDesignAlternatives;
                }

                    var totalScores = allDesignAlternatives.Sum(d => d.Score);

                    decimal accessibilityAddedValue = allDesignAlternatives.Max(d => d.AccessibilityAddedValue);
                    var totalAccessibilities = allDesignAlternatives.Sum(d => d.AccessibilityTotal + accessibilityAddedValue);

                    decimal relationAddedValue = allDesignAlternatives.Max(d => d.RelationAddedValue);
                    var totalRelations = allDesignAlternatives.Sum(d => d.RelationTotal + relationAddedValue);

                    decimal sizeAddedValue = allDesignAlternatives.Max(d => d.SizeAddedValue);
                    var totalSizes = allDesignAlternatives.Sum(d => d.SizeTotal + sizeAddedValue);

                    var totalSpaceFunctionalities = totalAccessibilities + totalRelations + totalSizes;

                    decimal costAddedValue = allDesignAlternatives.Max(d => d.CostAddedValue);
                    var totalCost = allDesignAlternatives.Sum(d => d.CostTotal + costAddedValue);

                    decimal timeAddedValue = allDesignAlternatives.Max(d => d.TimeAddedValue);
                    var totalTime = allDesignAlternatives.Sum(d => d.TimeTotal + timeAddedValue);

                    var totalConstructionsPerformances = totalCost + totalTime;

                    decimal energyAddedValue = allDesignAlternatives.Max(d => d.EnergyAddedValue);
                    var totalEnergy = allDesignAlternatives.Sum(d => d.EnergyTotal + energyAddedValue);

                    decimal maintenanceAddedValue = allDesignAlternatives.Max(d => d.MaintenanceAddedValue);
                    var totalMaintenance = allDesignAlternatives.Sum(d => d.MaintenanceTotal + maintenanceAddedValue);

                    var totalOperationPerformances = totalMaintenance + totalEnergy;

                    decimal aestheticsAddedValue = allDesignAlternatives.Max(d => d.AestheticsAddedValue);
                    var totalAestheticses = allDesignAlternatives.Sum(d => d.AestheticsTotal + aestheticsAddedValue);

                    if (totalScores > 0)
                    {
                        int rank = 1;
                        foreach (var designAlternative in allDesignAlternatives.OrderByDescending(d => d.Score))
                        {
                            designAlternative.Rank = rank++;
                            designAlternative.Percentage = decimal.Round((designAlternative.Score / totalScores) * 100m, 2, MidpointRounding.AwayFromZero);

                            designAlternative.AccessibilityPercentage = totalAccessibilities > 0 ?
                                decimal.Round(((designAlternative.AccessibilityTotal + accessibilityAddedValue) / totalAccessibilities) * 100m, 2, MidpointRounding.AwayFromZero) : 0;

                            designAlternative.RelationPercentage = totalRelations > 0 ?
                                decimal.Round(((designAlternative.RelationTotal + relationAddedValue) / totalRelations) * 100m, 2, MidpointRounding.AwayFromZero) : 0;

                            designAlternative.SizePercentage = totalSizes > 0 ?
                                decimal.Round(((designAlternative.SizeTotal + sizeAddedValue) / totalSizes) * 100m, 2, MidpointRounding.AwayFromZero) : 0;

                            designAlternative.SpaceFunctionalityPercentage = totalSpaceFunctionalities > 0 ?
                                decimal.Round(((designAlternative.SpaceFunctionalityTotal +
                                    accessibilityAddedValue + relationAddedValue + sizeAddedValue) / totalSpaceFunctionalities) * 100m, 2, MidpointRounding.AwayFromZero) : 0;

                            designAlternative.CostPercentage = totalCost > 0 ?
                                decimal.Round(((designAlternative.CostTotal + costAddedValue) / totalCost) * 100m, 2, MidpointRounding.AwayFromZero) : 0;

                            designAlternative.TimePercentage = totalTime > 0 ?
                                decimal.Round(((designAlternative.TimeTotal + timeAddedValue) / totalTime) * 100m, 2, MidpointRounding.AwayFromZero) : 0;

                            designAlternative.ConstructionPerformancePercentage = totalConstructionsPerformances > 0 ?
                                decimal.Round(((designAlternative.ConstructionPerformanceTotal +
                                    costAddedValue + timeAddedValue) / totalConstructionsPerformances) * 100m, 2, MidpointRounding.AwayFromZero) : 0;

                            designAlternative.EnergyPercentage = totalEnergy > 0 ?
                                decimal.Round(((designAlternative.EnergyTotal + energyAddedValue) / totalEnergy) * 100m, 2, MidpointRounding.AwayFromZero) : 0;

                            designAlternative.MaintenancePercentage = totalMaintenance > 0 ?
                               decimal.Round(((designAlternative.MaintenanceTotal + maintenanceAddedValue) / totalMaintenance) * 100m, 2, MidpointRounding.AwayFromZero) : 0;

                            designAlternative.OperationPerformancePercentage = totalOperationPerformances > 0 ?
                                decimal.Round(((designAlternative.OperationPerformanceTotal +
                                    energyAddedValue + maintenanceAddedValue) / totalOperationPerformances) * 100m, 2, MidpointRounding.AwayFromZero) : 0;

                            designAlternative.AestheticsPercentage = totalAestheticses > 0 ?
                                decimal.Round(((designAlternative.AestheticsTotal + aestheticsAddedValue) / totalAestheticses) * 100m, 2, MidpointRounding.AwayFromZero) : 0;
                        }
                    }

                    return allDesignAlternatives;
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

        public async Task<int> AddNewDesigns(int designsCount)
        {
            if(designsCount < 1)
            {
                return 0;
            }
            try
            {
                var currentAlternatives = await designAlternativesContext.DesignAlternatives.ToListAsync();

                if ((currentAlternatives.Count + designsCount) > 10 )
                {
                    return 0;
                }

                var newAlternatives = new List<DesignAlternative>();

                char[] letters = new char[] { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J' };

                for (int i = 0; i < currentAlternatives.Count + designsCount; i++)
                {
                    if(i < currentAlternatives.Count)
                    {
                        continue;
                    }

                    for (int l = 0; l < 10; l++)
                    {
                        char dName = letters[l];

                        if(currentAlternatives.Any(d => d.Name == dName.ToString()))
                        {
                            continue;
                        }

                        newAlternatives.Add(new DesignAlternative
                        {
                            Name = $"{letters[l]}"
                        });
                        break;
                    }
                    
                    
                }

                //designAlternativesContext.DesignAlternatives.RemoveRange(currentAlternatives);

                designAlternativesContext.DesignAlternatives.AddRange(newAlternatives);

                return await Save();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<int> Delete(DesignAlternative currentDesignAlternative)
        {
            try
            {
                this.designAlternativesContext.DesignAlternatives.Remove(currentDesignAlternative);
                return this.designAlternativesContext.SaveChanges();

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
