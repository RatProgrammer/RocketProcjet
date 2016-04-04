using System;
using WPFP.CommunicationLayer.Enums;
using WPFP.CommunicationLayer.Interfaces;
using WPFP.Core.ScoringItems;
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
            GoalTypeAchivment(goalType);
            ResearchedCocpitAchivment();
            RocetAssembledAchivment();
            CheckingParameters();
        }

        public void CheckingParameters()
        {
            ScoringReader scoringReader = new ScoringReader();
            ScoringContainer scoringContainer = scoringReader.ReadParameters();
            double budget = scoringContainer.Budget;
            double scientist = scoringContainer.Scientists;
            double engineers = scoringContainer.Engineers;
            double popularity = scoringContainer.Popularity;

            if(budget<1000)
                _scoringMechanism.Increase(1000);
            if(budget<250)
                _scoringMechanism.Increase(250);
            if(budget<50)
                _scoringMechanism.Increase(250);
            if(popularity>50)
                _scoringMechanism.Increase(500);
            if(budget<500 && (engineers+scientist)<40)
                _scoringMechanism.Increase(500);
            if((engineers+scientist)<20)
                _scoringMechanism.Increase(500);
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
            if (_scoringMechanism.WasEventPublished(EventType.UniversalBatteryResearched.ToString()) ||
                _scoringMechanism.WasEventPublished(EventType.MoreEfficientTransportationTakesWorldByStorm.ToString()))
            {
                _scoringMechanism.Increase(1000);
            }
        }

        private void HealthCareAchivment(GoalType goalType)
        {

            if (_scoringMechanism.WasEventPublished(EventType.CleanerFuelResearched.ToString()) ||
                _scoringMechanism.WasEventPublished(EventType.SafeStimulantsSold.ToString()))
            {
                _scoringMechanism.Increase(1000);

            }
        }

        private void GoalTypeAchivment(GoalType goalType)
        {
            switch (goalType)
            {
                case GoalType.SmartCity:
                    SmartCityAchivment(goalType);
                    break;
                case GoalType.Healthcare:
                    HealthCareAchivment(goalType);
                    break;
                case GoalType.All:
                    SmartCityAchivment(goalType);
                    HealthCareAchivment(goalType);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(goalType), goalType, null);
            }
        }
    }
}
