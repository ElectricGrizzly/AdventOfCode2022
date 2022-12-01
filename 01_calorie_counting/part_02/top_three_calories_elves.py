def calorie_counter() -> None:
    from config import DATA_DIRECTORY, INPUT_FILE_NAME, TARGET_ELVES

    calories_list: list[str] = get_calories_from_file(DATA_DIRECTORY, INPUT_FILE_NAME)
    top_most_calories: int = get_top_most_calories(calories_list, TARGET_ELVES)
    print(top_most_calories)

def get_calories_from_file(filepath: str, filename: str) -> list[str]:
    with open(filepath + filename) as file:
        return file.readlines()

def get_top_most_calories(calories_list: list[str], number_to_sort: int = 3) -> int:
    top_numbers: dict[int, int] = get_top_dict(number_to_sort)
    sum: int = 0
    for food_calories in calories_list:
        if food_calories == '\n':
            if (sum > top_numbers[0]):
                top_numbers = add_and_sort_top_numbers(top_numbers, sum)
                print(top_numbers)
            print(sum)
            sum = 0
            continue
        sum += int(food_calories)
    return sum_dictionary_values(top_numbers)

def sum_dictionary_values(dictionary: dict[int, int]) -> int:
    sum: int = 0
    for value in dictionary.values():
        sum += value
    return sum

def add_and_sort_top_numbers(dictionary: dict[int, int], number_to_add: int) -> dict[int, int]:
    last_index: int = len(dictionary) - 1
    for index in range(last_index):
        if number_to_add > dictionary[index] and number_to_add <= dictionary[index + 1]:
            current_num: int = dictionary[index]
            dictionary[index] = number_to_add
            add_and_sort_top_numbers(dictionary, current_num)
    if number_to_add > dictionary[last_index]:
        current_num: int = dictionary[last_index]
        dictionary[last_index] = number_to_add
        add_and_sort_top_numbers(dictionary, current_num)
    return dictionary


def get_top_dict(dictionary_key_number: int) -> dict[int, int]:
    dictionary: dict[int, int] = {}
    for integer in range(dictionary_key_number):
        dictionary[integer] = 0
    return dictionary

if __name__ == '__main__':
    calorie_counter()