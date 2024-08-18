
import HorizontallScrollList from "../List/HorizontalScrollList/HorizontalScrollList";
import PizzaItem from "../PizzaItem/PizzaItem";
import PopularProduct from "../PopularPizza/PopularPizza";
import styles from "./Products.module.css"

const Products = () => {
    return (
        <div className={styles.main}>
            <section className={styles.ofenOrder}>
                <label >Часто заказывают</label>
                {/* <div>
                    <PopularProduct />
                </div> */}
                <HorizontallScrollList/>
            </section>
            <section className={styles.pizzas}>
                <label>Пиццы</label>
                <div className={styles.pizzasContainer}>
                    <PizzaItem/>
                    <PizzaItem/>
                    <PizzaItem/>
                    <PizzaItem/>
                    <PizzaItem/>
                    <PizzaItem/>
                    <PizzaItem/>
                    <PizzaItem/>
                    <PizzaItem/>
                    <PizzaItem/>
                    <PizzaItem/>
                    <PizzaItem/>
                </div>
            </section>
            <section className={styles.breakfast}>

            </section>
            <section className={styles.snacks}>

            </section>
            <section className={styles.drink}>

            </section>
            <section className={styles.cocktails}>

            </section>
            <section className={styles.coffes}>

            </section>
            <section className={styles.deserts}>

            </section>
            <section className={styles.sauces}>

            </section>
        </div>
    )
}

export default Products;