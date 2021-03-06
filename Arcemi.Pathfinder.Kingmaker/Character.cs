﻿#region License
/* This Source Code Form is subject to the terms of the Mozilla Public
 * License, v. 2.0. If a copy of the MPL was not distributed with this
 * file, You can obtain one at http://mozilla.org/MPL/2.0/. */
 #endregion
using Newtonsoft.Json.Linq;

namespace Arcemi.Pathfinder.Kingmaker
{
    public class CharacterModel : RefModel
    {
        public CharacterModel(ModelDataAccessor accessor) : base(accessor)
        {
            N.On(nameof(CustomName), nameof(Name));
        }

        public ProgressionModel Progression => A.Object(factory: a => new ProgressionModel(a));
        public UISettingsModel UISettings => A.Object(factory: a => new UISettingsModel(a, Blueprint));
        public AlignmentModel Alignment => A.Object(factory: a => new AlignmentModel(a));
        public StatsModel Stats => A.Object(factory: a => new StatsModel(a));
        public UnitModel Unit => A.Object(factory: a => new UnitModel(a));
        public InventoryModel Inventory => A.Object<InventoryModel>("m_Inventory");
        public BodyModel Body => A.Object(factory: a => new BodyModel(a));

        public string Blueprint => A.Value<string>();
        public string CustomName { get => A.Value<string>(); set => A.Value(value); }
        public string Name
        {
            get => CustomName.OrIfEmpty(Mappings.GetCharacterName(Blueprint));
            set => CustomName = value;
        }
        public bool IsPlayer => Mappings.IsPlayerCharacter(Blueprint);
        public bool IsCustom => Mappings.IsCustomCharacter(Blueprint);
        public bool IsCompanion => Mappings.IsCompanionCharacter(Blueprint);

    }
}