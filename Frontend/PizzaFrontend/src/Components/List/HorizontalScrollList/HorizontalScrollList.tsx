
import PopularProduct from "../../PopularPizza/PopularPizza";
import styles from "./HorizontalScrollList.module.css"

import arrowPrev from "../../../assets/Inputs/previous.png"
import arrowNext from "../../../assets/Inputs/next.png"
import { useRef } from "react";

const HorizontallScrollList = () => {
    const prevBtn = useRef<HTMLDivElement>(null);
    const nextBtn = useRef<HTMLDivElement>(null);
    const data = useRef<HTMLDivElement>(null);
    
    const handleScrollElements = (value: number) => {
        if(data.current)
        {
            data.current.scrollBy(
                {
                    left: value,
                    behavior: "smooth"
                });
        }
    }

    const handleMouseEnterElements = (value: number) => {
        if(data.current)
        {
            const currentScroll = data.current.scrollLeft;
            const maxScroll = Math.abs(data.current.scrollWidth - data.current.clientWidth);

            if(currentScroll == 0 || maxScroll - currentScroll <= 1)
            {
                return;
            }

            data.current.scrollBy(
                {
                    left: value,
                    behavior: "smooth"
                }
            )
        }
    }

    const hideElement = (): void => {
        
        if(data.current && 
            prevBtn.current && 
            nextBtn.current)
        {
            const maxScroll = data.current.scrollWidth - data.current.clientWidth;
            const currentScroll = data.current.scrollLeft;

            if( currentScroll == 0)
            {
                prevBtn.current.className += " " + styles.hideElement; 
            }
            else {
                prevBtn.current.className = `${styles.btnContainer} ${styles.btnContainerPrev}`
            }

            if(Math.abs(maxScroll - currentScroll) <= 1)
            {
                nextBtn.current.className += " " + styles.hideElement;
            }
            else
            {
                nextBtn.current.className = `${styles.btnContainer} ${styles.btnContainerNext}`
            }
        }
    }

    return (
        <div className={styles.container}>
            <div ref={prevBtn}
                onMouseEnter={() => handleMouseEnterElements(-30)} 
                onMouseLeave={() => handleMouseEnterElements(30)} 
                onClick={() => handleScrollElements(-150)}
                className={`${styles.btnContainer} 
                            ${styles.btnContainerPrev}`}>
                <img src={arrowPrev} alt="previus arrow" />
            </div>
            <div onScroll={() => hideElement()} ref={data} className={styles.dataWrapper}>
                <PopularProduct />
                <PopularProduct />
                <PopularProduct />
                <PopularProduct />
                <PopularProduct />
                <PopularProduct />
                <PopularProduct />
                <PopularProduct />
                <PopularProduct />
                
            </div>
            <div ref={nextBtn}
                onClick={() => handleScrollElements(150)} 
                onMouseEnter={() => handleMouseEnterElements(30)}
                onMouseLeave={() => handleMouseEnterElements(-30)}
                className={`${styles.btnContainer} 
                            ${styles.btnContainerNext}`}>
                <img src={arrowNext} alt="next arrow" />
            </div>
        </div>
    )
}

export default HorizontallScrollList;