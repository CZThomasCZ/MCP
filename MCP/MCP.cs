using Smod2;
using Smod2.Attributes;
using Smod2.Events;
using Smod2.API;
using Smod2.EventHandlers;
using System;
using Smod2.Config;
using System.Collections.Generic;

namespace MCP
{
    [PluginDetails(
        author = "Matthew05",
        name = "Matthew's Content Pack",
        description = "Main plugin for the rest of my customizations",
        id = "matthew.main",
        configPrefix = "mcp",
        version = "1.1.0",
        SmodMajor = 3,
        SmodMinor = 0,
        SmodRevision = 0
        )]
    public class MCP : Plugin
    {
        public override void OnDisable()
        {

        }
        public override void OnEnable()
        {
            Info("Matthew's Content Pack loaded!");
        }
        public override void Register()
        {
            AddEventHandlers(new PluginHandler());
        }
    }
}

namespace gmLCZEscape
{
    [PluginDetails(
        author = "Matthew05",
        name = "LCZ Escape",
        description = "Light Containment Zone escape",
        id = "matthew.gamemode.lcz_escape",
        version = "1.1.0",
        configPrefix = "mcp",
        SmodMajor = 3,
        SmodMinor = 0,
        SmodRevision = 0
        )]
    public class GMlczEscape : Plugin
    {
        public override void OnDisable()
        {

        }

        public override void OnEnable()
        {
            //Info("Light Containment Zone escape enabled.");
        }

        public override void Register()
        {
            string queue = ConfigManager.Manager.Config.GetStringValue("mcp_lcz_queue", "30434044334044404444", false);
            GamemodeManager.GamemodeManager.RegisterMode(this, queue);
        }
    }
}

namespace gmNormal
{
    [PluginDetails(
        author = "Matthew05",
        name = "Normal gamemode",
        description = "Normal gamemode",
        id = "matthew.gamemode.normal",
        version = "1.1.0",
        configPrefix = "mcp",
        SmodMajor = 3,
        SmodMinor = 0,
        SmodRevision = 0
        )]
    public class GMNormal : Plugin
    {
        public override void OnDisable()
        {

        }

        public override void OnEnable()
        {
            //Info("Normal gamemode enabled.");
        }

        public override void Register()
        {
            string queue = ConfigManager.Manager.Config.GetStringValue("mcp_normal_queue", "40143140314414041340", false);
            GamemodeManager.GamemodeManager.RegisterMode(this, queue);
        }
    }
}

namespace gmDBoiz
{
    [PluginDetails(
        author = "Matthew05",
        name = "D-Boiz escape",
        description = "D-Boiz escape",
        id = "matthew.gamemode.dboiz",
        version = "1.1.0",
        configPrefix = "mcp",
        SmodMajor = 3,
        SmodMinor = 0,
        SmodRevision = 0
        )]
    public class GMDBoiz : Plugin
    {
        public override void OnDisable()
        {

        }

        public override void OnEnable()
        {
            //Info("D-Boiz escape enabled.");
        }

        public override void Register()
        {
            string queue = ConfigManager.Manager.Config.GetStringValue("mcp_dboiz_queue", "40444440444044404444", false);
            GamemodeManager.GamemodeManager.RegisterMode(this, queue);
        }
    }
}

namespace gmMTF
{
    [PluginDetails(
        author = "Matthew05",
        name = "MTF Recontainment",
        description = "MTF Recontainment",
        id = "matthew.gamemode.mtf",
        version = "1.1.0",
        configPrefix = "mcp",
        SmodMajor = 3,
        SmodMinor = 0,
        SmodRevision = 0
        )]
    public class GMMTF : Plugin
    {
        public override void OnDisable()
        {

        }

        public override void OnEnable()
        {
            //Info("MTF Recontainment enabled.");
        }

        public override void Register()
        {
            string queue = ConfigManager.Manager.Config.GetStringValue("mcp_mtf_queue", "10111110110111101111", false);
            GamemodeManager.GamemodeManager.RegisterMode(this, queue);
        }
    }
}

namespace gmRaid
{
    [PluginDetails(
        author = "Matthew05",
        name = "Facility Raid",
        description = "Facility Raid",
        id = "matthew.gamemode.raid",
        version = "1.1.0",
        configPrefix = "mcp",
        SmodMajor = 3,
        SmodMinor = 0,
        SmodRevision = 0
        )]
    public class GMCI : Plugin
    {
        public override void OnDisable()
        {

        }

        public override void OnEnable()
        {
            //Info("MTF Recontainment enabled.");
        }

        public override void Register()
        {
            string queue = ConfigManager.Manager.Config.GetStringValue("mcp_raid_queue", "40543540354454045340", false);
            GamemodeManager.GamemodeManager.RegisterMode(this, queue);
        }
    }
}