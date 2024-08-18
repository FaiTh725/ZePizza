import Navigatin, { Pair } from "../Components/Havigation/Navigation";
import Header from "../Components/Header/Header";
import HistoryOrder from "../Components/HistoryOrder/HistoryOrder";
import ProfileInformation from "../Components/ProfileInformation/ProfileInformation";
import Subscptions from "../Components/Subscriptions/Subscriptions";

const ProfileScreen = () => {
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
            <section style={{marginTop: "100px", }}>
                <ProfileInformation/>
            </section>
            <section style={{marginTop: "100px", }}>
                <Subscptions/>
            </section>
            <section style={{marginTop: "100px", }}>
                <HistoryOrder/>
            </section>
        </main>
    )
}

export default ProfileScreen;