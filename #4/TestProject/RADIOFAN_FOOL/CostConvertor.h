#ifndef CostConvertor_H
#define CostConvertor_H

class CostConvertor{
	private:
        static const wchar_t cost_to_letter[5];
	public:

		/*
		 * Конвертирует стоимость карты в букву
		 * @return
		 * 2-9 -> '2' - '9'
		 * 10 -> '0'
		 * 11 -> 'В'
		 * 12 -> 'Д'
		 * 13 -> 'К'
		 * 14 -> 'Т'
		 * 
		 * @throw wchar_t*
		 */
		static wchar_t cost2letter(uint8_t cost){
			if(cost > 1 && cost < 10)
				return L'0' + cost;
			if(cost > 9 && cost < 15){
				return cost_to_letter[cost-10];
			}
			throw L"cost out of range 2-14";
		}

		/*
		 * Конвертирует букву в стоимость карты
		 * @return
		 * '2' - '9' -> 2-9
		 * '0' -> 10
		 * 'В' -> 11
		 * 'Д' -> 12
		 * 'К' -> 13
		 * 'Т' -> 14
		 * 
		 * @throw wchar_t*
		 */
		static uint8_t letter2cost(wchar_t letter){
			if(letter >= L'2' && letter <= L'9')
				return letter - L'0';
			for(uint8_t i=0; i<5; i++){
				if(cost_to_letter[i] == letter)
					return i+10;
			}
			throw L"letter out of range";
		}

};

#endif // !CostConvertor_H