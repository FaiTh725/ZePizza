
import styles from "./PizzaItem.module.css"
import pizza from "../../assets/Pizzas/Pizza1.avif"
import SelectButton from "../Buttons/SelectButton/SelectButton";
import FullScreenProduct from "../FullScreenProduct/FullScreenProduct";
import { useState } from "react";
import ProductSetting from "../ProductSetting/ProductSetting";

const PizzaItem = () => {
    const [isOpenFullScreen, setIsOpenFullScreen] = useState(false);

    return (
        <div onClick={() => setIsOpenFullScreen(!isOpenFullScreen)} className={styles.main}>
            <div className={styles.imgContainer}>
                <img src={pizza} alt="pizza" />
            </div>
            <div className={styles.shortInfo}>
                <p className={styles.name}>Баварская</p>
                <p className={styles.ingridients}>Баварские колбаски, маринованные огурчики, красный лук, томаты, горчичный соус, моцарелла, фирменный томатный соус</p>
            </div>
            <div className={styles.buyProduct}>
                <div className={styles.price}>
                    от 21,99 руб.
                </div>
                <div className={styles.btnBuy}>
                    <SelectButton action={() => {}}>
                        <p>Выбрать</p>
                    </SelectButton>
                </div>
            </div>
            <FullScreenProduct isClose={isOpenFullScreen} setIsClose={() => setIsOpenFullScreen(!isOpenFullScreen)}>
                <ProductSetting/>
            </FullScreenProduct>
        </div>
    )
}

export default PizzaItem;