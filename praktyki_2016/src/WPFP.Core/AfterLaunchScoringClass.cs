using WPFP.CommunicationLayer.Enums;
using WPFP.CommunicationLayer.Interfaces;
using WPFP.Psyche;
using WPFP.Psyche.StateMachine;
using WPFP.SimConfiguration.Dependency;

namespace WPFP.Core
{
    public class AfterLaunchScoringMechanism : IAfterLaunchEvent
    {
        private ScoringMechanism _scoringMechanism;

        public AfterLaunchScoringMechanism(ScoringMechanism scoringMechanism)
        {
           _scoringMechanism = scoringMechanism;
        }

        public void Launch()
        {
            GoalType goalType = _scoringMechanism.GoalType();
            SmartCityAchivment(goalType);
            HealthCareAchivment(goalType);
            ResearchedCocpitAchivment();
            RocetAssembledAchivment();

        }

        private void RocetAssembledAchivment()
        {
            if (_scoringMechanism.WasEventPublished(EventType.RocketAssembled.ToString()))
            {
                _scoringMechanism.Increase(1000);
            }
        }

        private void ResearchedCocpitAchivment()
        {
            if (_scoringMechanism.WasEventPublished(EventType.ResearchedCockpit.ToString()))
            {
                _scoringMechanism.Increase(1000);
            }
        }

        private void SmartCityAchivment(GoalType goalType)
        {
            if (goalType == GoalType.SmartCity)
            {
                if (_scoringMechanism.WasEventPublished(EventType.UniversalBatteryResearched.ToString()) ||
                    _scoringMechanism.WasEventPublished(EventType.MoreEfficientTransportationTakesWorldByStorm.ToString()))
                {
                    _scoringMechanism.Increase(1000);
                }
            }
        }

        private void HealthCareAchivment(GoalType goalType)
        {
            if (goalType == GoalType.Healthcare)
            {
                if (_scoringMechanism.WasEventPublished(EventType.CleanerFuelResearched.ToString()) ||
                    _scoringMechanism.WasEventPublished(EventType.SafeStimulantsSold.ToString()))
                {
                    _scoringMechanism.Increase(1000);
                }
            }
        }
    }
    
}
