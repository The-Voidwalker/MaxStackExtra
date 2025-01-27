using Terraria;
using Terraria.ModLoader;
using System;
using Terraria.ID;

namespace MaxStackExtra
{
    public class MaxStackExtraItem : GlobalItem
    {

        public override bool CloneNewInstances => true;

        public override void SetDefaults(Item item)
        {
            if (!(item.type == ItemID.CopperCoin || item.type == ItemID.SilverCoin || item.type == ItemID.GoldCoin || item.type == ItemID.PlatinumCoin))
            {
                if (item.damage > 0 && item.ammo == 0 && !item.consumable)
                    item.maxStack = mod.GetConfig<MaxStackExtraConfig>().WeaponStackValue;
                else if (item.createTile > 0)
                    item.maxStack = mod.GetConfig<MaxStackExtraConfig>().TileStackValue;
                else if (item.accessory || item.defense > 0)
                    item.maxStack = mod.GetConfig<MaxStackExtraConfig>().EquipStackValue;
                else if (!item.accessory && item.damage == 0 && item.defense == 0 && item.createTile == 0 && item.maxStack == 1)
                    item.maxStack = mod.GetConfig<MaxStackExtraConfig>().SpecialStackValue;
                else if (item.maxStack > 1)
                    item.maxStack = mod.GetConfig<MaxStackExtraConfig>().ItemStackValue;
            }
            else
                base.SetDefaults(item);
        }
    }
}