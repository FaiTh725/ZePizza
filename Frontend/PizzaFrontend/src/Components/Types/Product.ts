
interface Product {
    id: number;
    urlImg: string;
    name: string;
    price: string;
    sizeType: SizeType;
    borderType: BorderType
    radius: number;
    ingridients: IngridientStatus[],
    additives: Additive[],
}

interface Additive {
    id: number;
    name: string;
    price: number
}

enum IngridientStatus {
    changable,
    unchangable
}

enum BorderType {
    Tradition,
    Slim
}

enum SizeType {
    Small,
    Medium,
    Large
}