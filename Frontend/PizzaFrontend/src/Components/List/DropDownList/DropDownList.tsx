
import { ReactNode, useEffect, useRef, useState } from "react";
import styles from "./DropDownList.module.css"

import arowDownGray from "../../../assets/Inputs/arrowDownGray.png"
import arrowDownOrange from "../../../assets/Inputs/arrowDownOrange.png"

interface DropDownListProps<T extends ReactNode> {
    label: string;
    values: GenericPair<T, string>[];
    value: T;
    setValue: (value: T) => void;
}

export type GenericPair<T1, T2> = {
    key: T1;
    value: T2;
}

const vls:GenericPair<number, string>[] = [
    {key: 1, value: "1"},
    {key: 2, value: "2"},
    {key: 3, value: "3"},
    {key: 4, value: "4"},
    {key: 5, value: "5"},
    {key: 6, value: "6"},
    {key: 7, value: "7"},
    {key: 8, value: "8"},
    {key: 9, value: "9"},
    {key: 10, value: "10"},
] 

const DropDownList = <T extends ReactNode,>({label, value, setValue, values = [],}: DropDownListProps<T>) => {
    const [isOpenValues, setIsOpenValues] = useState<boolean>(false);
    const [image, setImage] = useState<string>(arowDownGray);
    const listRef = useRef<HTMLDivElement>(null);

    

    const handleClickOutSide = (e: MouseEvent) => {
        if(listRef.current && !listRef.current.contains(e.target as Node))
        {   
            setIsOpenValues(false);
        }
    }

    useEffect(() => {
        if(isOpenValues)
        {   
            document.addEventListener("mousedown", handleClickOutSide);
        }
        else 
        {
            document.removeEventListener("mousedown", handleClickOutSide);
        }

        return () => {
            document.removeEventListener("mousedown", handleClickOutSide);
        }
    }, [isOpenValues]);

    return (
        <div ref={listRef} onMouseLeave={() => setImage(arowDownGray)} onMouseEnter={() => setImage(arrowDownOrange)} onClick={() => setIsOpenValues(!isOpenValues)} className={styles.container}>
            <p className={styles.name}>{label}</p>
            <div className={styles.arrowContainer}>   
                <img src={image} alt="arrow" />
                {/* <p>{String(value)}</p> */}
            </div>
            <div onClick={(e) => e.stopPropagation()} className={styles.valuesContainer + ` ${isOpenValues ? styles.isVisible : styles.isHidden}`}>
                {
                    vls.map(v => 
                        <p className={styles.value} onClick={() => {}}>{v.value}</p>
                    )
                }
            </div>
        </div>
    )
}

export default DropDownList;