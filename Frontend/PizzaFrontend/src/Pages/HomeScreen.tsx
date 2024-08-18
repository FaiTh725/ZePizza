import Navigatin from "../Components/Havigation/Navigation";
import Header from "../Components/Header/Header"
import Products from "../Components/Products/Products";

import { Pair } from "../Components/Havigation/Navigation";

const Home = () => {
    const navigation: Pair[] = [
        {key: "", value: "Пиццы"},
        {key: "", value: "Комбо"},
        {key: "", value: "Завтраки"},
        {key: "", value: "Закуски"},
        {key: "", value: "Напитки"},
        {key: "", value: "Коктейли"},
        {key: "", value: "Кофе"},
    ]

    return (
        <main style={{position: "relative", padding: "20px 180px", maxWidth: "1800px", margin: "0 auto"}}>
            <Header/>
            <Navigatin links={navigation}/>
            <Products/>
        </main>
    )
}

export default Home;