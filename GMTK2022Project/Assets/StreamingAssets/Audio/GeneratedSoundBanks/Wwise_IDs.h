/////////////////////////////////////////////////////////////////////////////////////////////////////
//
// Audiokinetic Wwise generated include file. Do not edit.
//
/////////////////////////////////////////////////////////////////////////////////////////////////////

#ifndef __WWISE_IDS_H__
#define __WWISE_IDS_H__

#include <AK/SoundEngine/Common/AkTypes.h>

namespace AK
{
    namespace EVENTS
    {
        static const AkUniqueID PLAY_MUSIC = 2932040671U;
        static const AkUniqueID PLAY_SWITCH_SX_NPC_FOOTSTEP = 2201991657U;
        static const AkUniqueID PLAY_SWITCH_SX_NPC_HURT = 2029174928U;
        static const AkUniqueID PLAY_SWITCH_SX_PLR_DODGEROLL = 3714387978U;
        static const AkUniqueID PLAY_SWITCH_SX_PLR_FOOTSTEP = 2412697160U;
        static const AkUniqueID PLAY_SWITCH_SX_PLR_HURT = 3330832805U;
        static const AkUniqueID PLAY_SWITCH_SX_WPN_DAGGER = 2216258413U;
        static const AkUniqueID PLAY_SWITCH_SX_WPN_GSWORD = 4044352437U;
        static const AkUniqueID PLAY_SWITCH_SX_WPN_WHOOSH = 1593694525U;
        static const AkUniqueID PLAY_SX_NPC_ATTACKCUE = 3640804643U;
        static const AkUniqueID PLAY_SX_NPC_DEATH = 3238803408U;
        static const AkUniqueID PLAY_SX_PLR_DEATH = 1837394887U;
        static const AkUniqueID PLAY_SX_UI_HOVER = 298035903U;
        static const AkUniqueID PLAY_SX_UI_SELECT = 1031467199U;
        static const AkUniqueID PLAY_SX_WPN_BOW = 1403214302U;
        static const AkUniqueID PLAY_SX_WPN_SHIELD = 2153006489U;
        static const AkUniqueID PLAY_SX_WPN_SPEAR = 2719353785U;
        static const AkUniqueID PLAY_SX_WPN_SWORD = 2999961825U;
    } // namespace EVENTS

    namespace STATES
    {
        namespace ONHIT
        {
            static const AkUniqueID GROUP = 3182539833U;

            namespace STATE
            {
                static const AkUniqueID NONE = 748895195U;
                static const AkUniqueID ONHIT = 3182539833U;
                static const AkUniqueID RECOVER = 1972544759U;
            } // namespace STATE
        } // namespace ONHIT

    } // namespace STATES

    namespace TRIGGERS
    {
        static const AkUniqueID ONHIT = 3182539833U;
    } // namespace TRIGGERS

    namespace BANKS
    {
        static const AkUniqueID INIT = 1355168291U;
        static const AkUniqueID MUSIC = 3991942870U;
        static const AkUniqueID NPCS = 833916109U;
        static const AkUniqueID PLAYER = 1069431850U;
        static const AkUniqueID UI = 1551306167U;
        static const AkUniqueID WEAPONS = 1467963052U;
    } // namespace BANKS

    namespace BUSSES
    {
        static const AkUniqueID MASTER_AUDIO_BUS = 3803692087U;
        static const AkUniqueID NPCS = 833916109U;
        static const AkUniqueID PLAYER = 1069431850U;
        static const AkUniqueID UI = 1551306167U;
        static const AkUniqueID WEAPONS = 1467963052U;
    } // namespace BUSSES

    namespace AUDIO_DEVICES
    {
        static const AkUniqueID NO_OUTPUT = 2317455096U;
        static const AkUniqueID SYSTEM = 3859886410U;
    } // namespace AUDIO_DEVICES

}// namespace AK

#endif // __WWISE_IDS_H__
