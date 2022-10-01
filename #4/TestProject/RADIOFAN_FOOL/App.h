#pragma once

#include "CostConvertor.h"
#include "Card.h"
#include "CardCouple.h"
#include "BrokenCards.h"
#include "PackCards.h"
#include "Player.h"
#include "PlayingField.h"
#include "GameLogic.h"

class App{
	private:
		App(){}
		App(const App&){}  
		App& operator=(App&){}
	public:
		static App& get_instance(){
			static App instance;
			return instance;
		}
};