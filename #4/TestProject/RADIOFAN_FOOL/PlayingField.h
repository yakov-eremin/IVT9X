#pragma once
class PlayingField_defenition : public NeedRedraw{
	private:
		std::vector<CardCouple> card_couples;


	protected:
		PlayingField_defenition(){
			reset();
		}

	public:
		const uint8_t MAX_CARD_COUPLES = 6;

		void reset(){
			card_couples.clear();
			this->need_redraw = true;
		}

		uint8_t count(){
			return (uint8_t)card_couples.size();
		}

		void add_card_couple(CardCouple& card_couple){
			if(card_couples.size() == MAX_CARD_COUPLES)
				throw L"Count of card couples reached the limit";
			card_couples.push_back(card_couple);
			this->need_redraw = true;
		}

		void add_card_couple(){
			if(card_couples.size() == MAX_CARD_COUPLES)
				throw L"Count of card couples reached the limit";
			card_couples.push_back(CardCouple());
			this->need_redraw = true;
		}

		CardCouple& get_card_couple(uint8_t ind){
			if(ind >= card_couples.size())
				throw L"ind out of range";
			
			return card_couples[ind];
		}

		bool is_all_card_couples_broken(){
			for(uint8_t i=0; i<card_couples.size(); i++){
				if(!card_couples[i].is_broken())
					return false;
			}
			
			return true;
		}

		bool can_add_card_couple(){
			return card_couples.size() < MAX_CARD_COUPLES;
		}

		void move_cards_to_broken(){
			BrokenCards& broken_cards = BrokenCards::get_instance();
			for(uint8_t i=0; i<card_couples.size(); i++){
				broken_cards.add(card_couples[i]);
			}
			this->reset();
		}

		bool can_add_attack_card(Card& attack){
			if(!card_couples.size())
				return true;
			for(uint8_t i=0; i<card_couples.size(); i++){
				if(card_couples[i].get_defense() && card_couples[i].get_defense()->get_cost() == attack.get_cost()
				|| card_couples[i].get_attack() && card_couples[i].get_attack()->get_cost() == attack.get_cost()
				){
					return true;
				}
			}
			return false;
		}

		int8_t get_right_not_broken_couple(int8_t ind){
			if(ind >= card_couples.size() || ind < 0)
				ind = -1;
			int8_t ret = -1;
			for(ind++; ind<card_couples.size(); ind++){
				if(!card_couples[ind].is_broken()){
					ret = ind;
					break;
				}
			}
			return ret;
		}

		int8_t get_left_not_broken_couple(int8_t ind){
			if(ind >= card_couples.size() || ind < 0)
				ind = card_couples.size();
			int8_t ret = -1;
			for(ind--; ind >= 0; ind--){
				if(!card_couples[ind].is_broken()){
					ret = ind;
					break;
				}
			}
			return ret;
		}
};

class PlayingField : public PlayingField_defenition{
	private:
		PlayingField(){}
		PlayingField(const PlayingField&){}  
		PlayingField& operator=(PlayingField&){}
	public:
		static PlayingField& get_instance(){
			static PlayingField instance;
			return instance;
		}
};