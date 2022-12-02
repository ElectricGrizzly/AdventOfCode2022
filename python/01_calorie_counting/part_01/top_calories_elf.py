def calorie_counter() -> None:
    from config import DATA_DIRECTORY, INPUT_FILE_NAME

    calories_list: list[str] = get_calories_from_file(DATA_DIRECTORY, INPUT_FILE_NAME)
    most_calories: int = get_most_calories(calories_list)
    print(most_calories)

def get_calories_from_file(filepath: str, filename: str) -> list[str]:
    with open(filepath + filename) as file:
        return file.readlines()

def get_most_calories(calories_list: list[str]) -> int:
    sum: int = 0
    greatest: int = 0
    for food_calories in calories_list:
        if food_calories == '\n':
            greatest = sum if sum > greatest else greatest
            sum = 0
            continue
        sum += int(food_calories)
    return greatest

if __name__ == '__main__':
    calorie_counter()