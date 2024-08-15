
import Additive from "../Additive/Additive";
import styles from "./ProductSetting.module.css"

import pizza from "../../assets/Pizzas/11EF1EB095B2BBDE8E1230BD91995D9D.avif"
import SettingButton from "../Buttons/SettingButton/SettingButton";
import Information from "../Information/Information";

const ProductSetting = () => {
    return (
        <div className={styles.main}>
            <div className={styles.imageContainer}>
                <img src={pizza} alt="" />
            </div>
            <div className={styles.productData}>
                <section className={styles.name}>
                    <p>Баварская</p>
                    {/* TODO Information click outside the element should close it */}
                    <Information>
                        <div className={styles.additionalInformation}>
                            <p>Пищевая ценность на 100 г</p>
                            <div className={styles.nutritionalValue}>
                                <section>
                                    <p>Энерг. ценность</p>
                                    <p>255.8 ккал</p>
                                </section>
                                <section>
                                    <p>Белки</p>
                                    <p>8.6 г</p>
                                </section>
                                <section>
                                    <p>Жиры</p>
                                    <p>10.7 г</p>
                                </section>
                                <section>
                                    <p>Углеводы</p>
                                    <p>29.6 г</p>
                                </section>
                                <section>
                                    <p>Вес</p>
                                    <p>860 г</p>
                                </section>
                            </div>
                            <p>Может содержать аллергены: клютены, молоко и продукты его переработки(в том числе дактозу), а также некоторые другие аллергены:</p>
                        </div>
                    </Information>
                </section>
                <section className={styles.productSize}>
                    <p>30 см, Традиционное тесто 30, 630 г</p>
                </section>
                <section className={styles.productIngridience}>
                    <label>Баварские колбаски, Маринованные огурчики, красный лук, томаты, соус горчичный, моцаредда, фирменный томатный соус</label>
                </section>
                <section className={styles.productTypes}>
                    <section className={styles.settingButtons}>
                        <SettingButton text="Маленькая" />
                        <SettingButton text="Средняя" />
                        <SettingButton text="Большая" />
                    </section>
                    <section className={styles.settingButtons}>
                        <SettingButton text="Традиционное" />
                        <SettingButton text="Тонкое" />
                    </section>
                </section>
                <section className={styles.productAdditives}>
                    <label>Добавить по вкусу</label>
                    <div className={styles.additives}>
                        <Additive/>
                        <Additive/>
                        <Additive/>
                        <Additive/>
                        <Additive/>
                        <Additive/>
                    </div>
                </section>
            </div>
        </div>
    )
}

export default ProductSetting;