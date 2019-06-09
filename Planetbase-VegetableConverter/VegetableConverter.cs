using System.Collections.Generic;
using Planetbase;
using UnityEngine;

namespace VegetableConverter
{
    //TODO At some point I'll move a lot of this boilerplate code to the framework
    public class VegetableConverter : ComponentType
    {
        //This component will pull in some information (icon, 3d model) from the bioplastic processor
        private static ComponentType ComponentInstance { get; } =
            TypeList<ComponentType, ComponentTypeList>.find<BioplasticProcessor>();

        public VegetableConverter()
        {
            //The cost to build the component
            mConstructionCosts = new ResourceAmounts();
            mConstructionCosts.add(TypeList<ResourceType, ResourceTypeList>.find<Metal>(), 1);

            //The icon to display when selecting the component on the module's component build menu.
            //This can also be loaded from the assets folder via mod.ModTextures.FindTextureWithName("icon.png");
            mIcon = ComponentInstance.getIcon();

            //The resources the component uses for each item it produces
            mResourceConsumption = new List<ResourceType> { TypeList<ResourceType, ResourceTypeList>.find<Vegetables>() };

            //The resource to produce
            addResourceProduction<Starch>();

            //The amount of the raw resources the component can hold at a time
            mEmbeddedResourceCount = 3;

            //How long (in seconds I think) it takes to produce one item
            mResourceProductionPeriod = 100f;

            //How much power the machine continuously uses (or produces)
            mPowerGeneration = -1000;

            //Various settings are configured by adding or bitwise-or flag constants together
            mFlags = FlagRequiresOperator + FlagCanBeDisabled + FlagStoreProduction;

            //Set who can use the component
            mOperatorSpecialization = TypeList<Specialization, SpecializationList>.find<Worker>();

            //Set the animation for working on the component
            addUsageAnimation(CharacterAnimationType.WorkStanding);

            mName = "Vegetable Converter";
            mTooltip = "Turns vegetables into starch.";
        }

        public override GameObject createModel() => ComponentInstance.createModel();
    }
}